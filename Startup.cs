using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Extensions;
using LagendaBackend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

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

			services.AddJsonApi<AppDbContext>(options =>
			{
				options.Namespace = "api/v1";
				options.DefaultPageSize = 20;
				options.IncludeTotalRecordCount = true;
				options.ValidateModelState = true;
			});

			services.AddCors();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "L'Agenda API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
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
				//app.UseHsts();
			}


			app.UseJsonApi();
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}