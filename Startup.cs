using System.Net;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Resources.Annotations;
using LagendaBackend.Clients;
using LagendaBackend.Configuration;
using LagendaBackend.Data.Models;
using LagendaBackend.Middlewares;
using LagendaBackend.Models;
using LagendaBackend.Services;
using LagendaBackend.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace LagendaBackend
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<ForwardedHeadersOptions>(options =>
			{
				options.ForwardedHeaders = ForwardedHeaders.All;
			});
			services.AddApplicationInsightsTelemetry();

			services.AddDbContext<AppDbContext>((sp, builder ) =>
			{
				var config = sp.GetRequiredService<IConfiguration>();
				builder.UseMySql(config.GetConnectionString("MysqlConnectionString"),
					ServerVersion.AutoDetect(config.GetConnectionString("MysqlConnectionString")),
					mySqlOptions => mySqlOptions.EnableRetryOnFailure()
				);
			});

			services.AddJsonApi<AppDbContext>(
				options =>
				{
					options.Namespace = "api/v1";
					options.ValidateModelState = true;
					options.SerializerSettings.ContractResolver = new DefaultContractResolver
					{
						NamingStrategy = new KebabCaseNamingStrategy()
					};
					options.EnableResourceHooks = true;
					options.IncludeTotalResourceCount = true;
					options.DefaultPageSize = new PageSize(100);
				}, discovery => discovery.AddCurrentAssembly());

			services.AddCors();
			services.AddControllers();
			services.AddHttpContextAccessor();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "L'Agenda API", Version = "v1" });
			});

			services.AddOptions<GoogleConfiguration>().BindConfiguration("Google").ValidateDataAnnotations();
			services.AddOptions<AuthenticationConfiguration>().BindConfiguration("Authentication").ValidateDataAnnotations();

			services.AddSingleton<GoogleClient>();
			services.AddSingleton<JwtParser>();
			services.AddSingleton<JwtService>();
			services.AddScoped<AuthenticationService>();
			services.AddSingleton<Base64Util>();
			services.AddSingleton<PermissionUtils>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseForwardedHeaders();
			app.UseRouting();


			app.UseCors(
				options => options
					.WithOrigins("http://localhost:4200", "https://www.lagenda.ca", "https://lagenda.ca")
					.AllowAnyMethod()
					.WithHeaders("content-type", "authorization")
			);

			app.UseMiddleware<AuthenticationMiddleware>();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				app.UseSwagger();

				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "L'Agenda API v1");
					c.RoutePrefix = string.Empty;
				});
			}
			else
			{
				app.UseHttpsRedirection();
			}

			app.UseJsonApi();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
			app.Use((context, _) =>
			{
				context.Response.StatusCode = StatusCodes.Status404NotFound;
				return context.Response.WriteAsJsonAsync(new {message = "Route not found."});
			});
		}
	}
}