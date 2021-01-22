using System;
using System.Linq;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.Resources;
using LagendaBackend.Data.Models;

namespace LagendaBackend.Data.Resources
{
	public class ArticleResource : JsonApiResourceDefinition<Article>
	{
		public ArticleResource(IResourceGraph resourceGraph) : base(resourceGraph)
		{

		}

		public override FilterExpression OnApplyFilter(FilterExpression existingFilter)
		{
			var resourceContext = ResourceGraph.GetResourceContext<Article>();

			var unlistedAttribute =
				resourceContext.Attributes.Single(a =>
					a.Property.Name == nameof(Article.Unlisted));
			var isUnlisted = new ComparisonExpression(ComparisonOperator.Equals,
				new ResourceFieldChainExpression(unlistedAttribute),
				new LiteralConstantExpression(bool.FalseString));

			var postDatetimeAttribute =
				resourceContext.Attributes.Single(a =>
					a.Property.Name == nameof(Article.PostDatetime));
			var isPublished = new ComparisonExpression(ComparisonOperator.LessThan,
				new ResourceFieldChainExpression(postDatetimeAttribute),new LiteralConstantExpression(DateTimeOffset.UtcNow.ToString("O"))
				);

			return existingFilter == null
				? (FilterExpression) isUnlisted
				: new LogicalExpression(LogicalOperator.And,
					new[] {isUnlisted, isPublished, existingFilter});
		}
	}
}