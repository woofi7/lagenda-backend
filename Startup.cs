using JsonApiDotNetCore.Configuration;
using LagendaBackend.Clients;
using LagendaBackend.Configuration;
using LagendaBackend.Data.Models;
using LagendaBackend.Middlewares;
using LagendaBackend.Models;
using LagendaBackend.Services;
using LagendaBackend.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
					options.IncludeExceptionStackTraceInErrors = true;
					options.SerializerSettings.ContractResolver = new DefaultContractResolver
					{
						NamingStrategy = new KebabCaseNamingStrategy()
					};
					options.EnableResourceHooks = true;
				}, discovery => discovery.AddCurrentAssembly());

			services.AddCors();
			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "L'Agenda API", Version = "v1" });
			});

			services.AddOptions<GoogleConfiguration>().BindConfiguration("Google").ValidateDataAnnotations();
			services.AddOptions<AuthenticationConfiguration>().BindConfiguration("Authentication").ValidateDataAnnotations();

			services.AddSingleton<GoogleClient>();
			services.AddSingleton<Base64Util>();
			services.AddSingleton<JwtParser>();
			services.AddSingleton<JwtService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
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
		}
	}
}