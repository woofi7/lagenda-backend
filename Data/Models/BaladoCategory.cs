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

		[Attr(PublicName = "desc")]
		public string Desc { get; set; }

		[Attr(PublicName = "unlisted")]
		public bool Unlisted { get; set; }

		[HasOne(PublicName = "image")]
		public Image Image { get; set; }

		[HasOne(PublicName = "partner")]
		public BaladoPartner BaladoPartner { get; set; }

		[HasMany(PublicName = "balados")]
		public ICollection<Balado> Balados { get; set; }
	}
}