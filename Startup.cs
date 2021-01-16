using JsonApiDotNetCore.Configuration;
using LagendaBackend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace LagendaBackend
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>();

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
				});

			services.AddCors();
			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "L'Agenda API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseRouting();

			app.UseCors(
				options => options.WithOrigins("http://localhost:4200", "https://www.lagenda.ca", "https://lagenda.ca").AllowAnyMethod()
			);

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