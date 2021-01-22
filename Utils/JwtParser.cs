using Jose;

namespace LagendaBackend.Utils
{
	public class JwtParser
	{
		public TTokenPayload GetTokenPayload<TTokenPayload>(string token)
		{
			return JWT.Payload<TTokenPayload>(token);
		}
	}
}