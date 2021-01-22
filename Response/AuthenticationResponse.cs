namespace LagendaBackend.Response
{
	public class AuthenticationResponse
	{
		public string AccessToken { get; set; }
		public UserInfoResponse UserInfo { get; set; }
	}
}