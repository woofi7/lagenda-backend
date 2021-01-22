using LagendaBackend.Data.Models;
using LagendaBackend.Models;

namespace LagendaBackend.Response
{
	public class UserInfoResponse
	{

		public string FirstName { get; set; }
		public string FamilyName { get; set; }
		public string Picture { get; set; }

		public static UserInfoResponse FromProfile(Profile profile)
		{
			return new UserInfoResponse
			{
				FirstName = profile.FirstName,
				FamilyName = profile.FamilyName,
				Picture = profile.Picture
			};
		}
	}
}