using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace LagendaBackend.Models
{
	public class BaladoCategory : Identifiable
	{
		[Attr("name")]
		public string Name { get; set; }

		[HasMany("balados")]
		public ICollection<Balado> Balados { get; set; }
	}
}