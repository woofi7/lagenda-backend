using System;
using System.Linq;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.Resources;
using LagendaBackend.Data.Models;

namespace LagendaBackend.Data.Resources
{
	public class BaladoResource : JsonApiResourceDefinition<Balado>
	{
		public BaladoResource(IResourceGraph resourceGraph) : base(resourceGraph)
		{
		}

		public override FilterExpression OnApplyFilter(FilterExpression existingFilter)
		{
			var resourceContext = ResourceGraph.GetResourceContext<Balado>();

			var unlistedAttribute =
				resourceContext.Attributes.Single(a =>
					a.Property.Name == nameof(Balado.Unlisted));
			var isUnlisted = new ComparisonExpression(ComparisonOperator.Equals,
				new ResourceFieldChainExpression(unlistedAttribute),
				new LiteralConstantExpression(bool.FalseString));

			var postDatetimeAttribute =
				resourceContext.Attributes.Single(a =>
					a.Property.Name == nameof(Balado.PostDatetime));
			var isPublished = new ComparisonExpression(ComparisonOperator.LessThan,
				new ResourceFieldChainExpression(postDatetimeAttribute),new LiteralConstantExpression(DateTimeOffset.UtcNow.ToString("O"))
				);

			return existingFilter == null
				? (FilterExpression) isUnlisted
				: new LogicalExpression(LogicalOperator.And,
					new[] {isUnlisted, isPublished, existingFilter});
		}

		// public override IEnumerable<Person> OnReturn(HashSet<Person> entities, ResourcePipeline pipeline)
		// {
		// 	if (!_auth.CanSeeSecretPeople())
		// 	{
		// 		if (pipeline == ResourcePipeline.GetSingle)
		// 		{
		// 			throw new JsonApiException(403, "Forbidden to view this person", new  UnauthorizedAccessException());
		// 		}
		// 		entities = entities.Where( p => !p.IsSecret)
		// 	}
		// 	return entities;
		// }
	}
}