using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using File = LagendaBackend.Data.Models.File;

namespace LagendaBackend.Controllers
{
	[Route("/api/v1")]
	[ApiController]
	public class UploadFileController : ControllerBase
	{

		private readonly BlobServiceClient _blobServiceClient;
		private readonly AppDbContext _appDbContext;
		private readonly AuthenticationService _authenticationService;

		public UploadFileController(BlobServiceClient blobServiceClient, AppDbContext appDbContext, AuthenticationService authenticationService)
		{
			_blobServiceClient = blobServiceClient;
			_appDbContext = appDbContext;
			_authenticationService = authenticationService;
		}

		[HttpPost("upload")]
		public async Task<ActionResult> UploadImage(IFormFile file)
		{
			var profile = await _authenticationService.GetCurrentProfile();
			if (profile == null)
				return Unauthorized();

			using var imageBitmap = SKBitmap.Decode(file.OpenReadStream());
			using var image = ResizeScaledImage(imageBitmap);

			using var data = image?.Encode(SKEncodedImageFormat.Webp, 90)
			                 ?? imageBitmap.Encode(SKEncodedImageFormat.Webp, 90);

			var imageId = Guid.NewGuid();
			var blobClient = _blobServiceClient.GetBlobContainerClient("images").GetBlobClient(imageId.ToString());
			await blobClient.UploadAsync(data.AsStream(), new BlobHttpHeaders() {ContentType = "image/webp"});

			await _appDbContext.Set<File>().AddAsync(new File()
			{
				Name = file.Name,
				DatetimeUploadedUtc = DateTimeOffset.UtcNow,
				FileId = imageId,
				Type = FileType.Image,
				Size = (int) file.Length,
				User = profile
			});

			await _appDbContext.SaveChangesAsync();

			return new JsonResult(new
			{
				Name = file.FileName,
				FileLink = blobClient.Uri.AbsoluteUri
			});
		}

		private static SKBitmap ResizeScaledImage(SKBitmap imageBitmap)
		{
			var widthRatio = 2048d / imageBitmap.Width;
			var heightRatio = 2048d / imageBitmap.Height;

			var bestRatio = Math.Min(widthRatio, heightRatio);

			if (bestRatio >= 1)
				return null;

			var newWidth = (int)(imageBitmap.Width * bestRatio);
			var newHeight = (int)(imageBitmap.Height * bestRatio);

			return imageBitmap.Resize(new SKImageInfo(newWidth, newHeight), SKFilterQuality.High);
		}
	}
}