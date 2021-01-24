using System;
using System.Linq;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.Resources;
using LagendaBackend.Data.Models;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class ArticleResource : JsonApiResourceDefinition<Article>
	{
		private readonly AuthenticationService _authenticationService;
		public ArticleResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph)
		{
			_authenticationService = authenticationService;
		}

		public override FilterExpression OnApplyFilter(FilterExpression existingFilter)
		{
			if (_authenticationService.CurrentUserHasPermission(Permissions.Article.ViewUnpublished))
				return existingFilter;

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