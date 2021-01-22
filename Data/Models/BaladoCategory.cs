using System.Collections.Generic;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace LagendaBackend.Data.Models
{
	public class BaladoCategory : Identifiable
	{
		[Attr(PublicName = "name")]
		public string Name { get; set; }

		[Attr(PublicName = "order")]
		public int? Order { get; set; }

		[HasMany(PublicName = "balados")]
		public ICollection<Balado> Balados { get; set; }
	}
}