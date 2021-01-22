using System.ComponentModel.DataAnnotations;

namespace LagendaBackend.Configuration
{
	public class GoogleConfiguration
	{
		[Required]
		public string AppId { get; set; }
		[Required]
		public string AppSecret { get; set; }
	}
}