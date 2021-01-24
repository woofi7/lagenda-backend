using System.Linq;

namespace LagendaBackend.Utils
{
	public class PermissionUtils
	{
		public bool CheckPermissions(string[] roles, string permission)
		{
			return roles.Contains(permission);
		}
	}

}