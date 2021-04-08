using System;
using JsonApiDotNetCore.Resources;

namespace LagendaBackend.Data.Models
{
	public class File : Identifiable
	{
		public Guid FileId { get; set; }
		public string Name { get; set; }
		public DateTimeOffset DatetimeUploadedUtc { get; set; }
		public Profile User { get; set; }
		public FileType Type { get; set; }
		public int Size { get; set; }
	}

	public enum FileType
	{
		Image,
		Audio
	}
}