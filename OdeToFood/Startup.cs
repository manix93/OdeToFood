﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;
using OdeToFood.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood
{
	public class Startup
	{
		private IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IGreeter, Greeter>();
			services.AddDbContext<OdeToFoodDbContext>(
				options => options.UseSqlServer(_configuration.GetConnectionString("OdeToFood")));
			services.AddScoped<IRestaurantData, SqlRestaurantData>(); //Scoped telling us that if we have IRestaurantData item put there InMemoryRestaurantData class
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, 
							  IHostingEnvironment env,
							  IGreeter greeter,
							  ILogger<Startup> logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			app.UseMvc(ConfigureRoutes);

			app.Run(async (context) =>
			{
				var greeting = greeter.GetMessageOfTheDay();
				await context.Response.WriteAsync(greeting);
			});
		}

		private void ConfigureRoutes(IRouteBuilder routeBuilder)
		{
			// /Home/Index
			routeBuilder.MapRoute("Default", 
				"{controller=Home}/{action=Index}/{id?}");
		}
	}
}
