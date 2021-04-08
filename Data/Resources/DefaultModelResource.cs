using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.Resources;
using LagendaBackend.Services;

namespace LagendaBackend.Data.Resources
{
	public class DefaultModelResource<TResource> : JsonApiResourceDefinition<TResource>
		where TResource : class, IIdentifiable<int>
	{
		private readonly AuthenticationService _authenticationService;

		public DefaultModelResource(IResourceGraph resourceGraph, AuthenticationService authenticationService) : base(resourceGraph)
		{
			_authenticationService = authenticationService;
		}

		public override FilterExpression OnApplyFilter(FilterExpression existingFilter)
		{
			if (_authenticationService.CurrentUserHasPermission(Permissions.General.ViewUnpublished))
				return existingFilter;

			var resourceContext = ResourceGraph.GetResourceContext<TResource>();
			var filtersList = new List<FilterExpression>();

			if (existingFilter != null)
			{
				filtersList.Add(existingFilter);
			}

			var unlistedAttribute =
				resourceContext.Attributes.SingleOrDefault(a =>
					a.Property.Name == "Unlisted");
			if (unlistedAttribute != null)
			{
				filtersList.Add(new ComparisonExpression(ComparisonOperator.Equals,
					new ResourceFieldChainExpression(unlistedAttribute),
					new LiteralConstantExpression(bool.FalseString)));
			}

			var postDatetimeAttribute =
				resourceContext.Attributes.SingleOrDefault(a =>
					a.Property.Name == "PostDatetime");
			if (postDatetimeAttribute != null)
			{
				filtersList.Add(new ComparisonExpression(ComparisonOperator.LessThan,
					new ResourceFieldChainExpression(postDatetimeAttribute),
					new LiteralConstantExpression(DateTimeOffset.UtcNow.ToString("O"))));
			}

			return filtersList.Count > 1 ?
				new LogicalExpression(LogicalOperator.And, filtersList.ToArray())
				: filtersList.FirstOrDefault();
		}
	}
}