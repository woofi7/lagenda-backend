namespace LagendaBackend.Models
{
	public class JwtTokenPayload
	{
		public JwtTokenPayload(int id)
		{
			UserId = id;
		}

		public int UserId { get; set; }
	}
}