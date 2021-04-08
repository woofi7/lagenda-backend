using System;
using System.Threading.Tasks;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using LagendaBackend.Utils;
using Microsoft.AspNetCore.Http;

namespace LagendaBackend.Services
{
	public class AuthenticationService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly PermissionUtils _permissionUtils;
		private readonly AppDbContext _dbContext;

		public readonly string[] RoleAdmin = { Permissions.General.ViewUnpublished };
		public readonly string[] RoleWriter = { };
		public readonly string[] RolesViewer = { Permissions.General.ViewUnpublished };
		public readonly string[] RolesAnonymous = Array.Empty<string>();

		public AuthenticationService(IHttpContextAccessor httpContextAccessor, PermissionUtils permissionUtils, AppDbContext dbContext)
		{
			_httpContextAccessor = httpContextAccessor;
			_permissionUtils = permissionUtils;
			_dbContext = dbContext;
		}

		public bool CurrentUserHasPermission(string permission)
		{
			if (!(_httpContextAccessor.HttpContext?.Items[typeof(JwtTokenPayload)] is JwtTokenPayload payload))
				return _permissionUtils.CheckPermissions(RolesAnonymous, permission);

			var profile = _dbContext.Set<Profile>().Find(payload.UserId);
			if (profile == null)
				return _permissionUtils.CheckPermissions(RolesAnonymous, permission);

			switch (profile.Role)
			{
				case "admin":
					return _permissionUtils.CheckPermissions(RoleAdmin, permission);
				case "writer":
					return _permissionUtils.CheckPermissions(RoleWriter, permission);
				case "viewer":
					return _permissionUtils.CheckPermissions(RolesViewer, permission);
				default:
					return _permissionUtils.CheckPermissions(RolesAnonymous, permission);
			}
		}

		public ValueTask<Profile> GetCurrentProfile()
		{
			if (!(_httpContextAccessor.HttpContext?.Items[typeof(JwtTokenPayload)] is JwtTokenPayload payload))
				return new ValueTask<Profile>(Task.FromResult<Profile>(null));

			return _dbContext.Set<Profile>().FindAsync(payload.UserId);
		}
	}

	public static class Permissions
	{
		public  static class General
		{
			public const string ViewUnpublished = "general.*";
		}
		public static class Article
		{
			public const string All = "article.*";
			public const string ViewUnpublished = "article.view-all";
			public const string Edit = "article.edit";
		}
	}
}