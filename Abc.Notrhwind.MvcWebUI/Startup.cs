using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Nortwind.DataAccess.Abstract;
using Abc.Nortwind.DataAccess.Concrete.EntityFramework;
using Abc.Notrhwind.MvcWebUI.Entities;
using Abc.Notrhwind.MvcWebUI.Middlewares;
using Abc.Notrhwind.MvcWebUI.UIServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Abc.Notrhwind.MvcWebUI
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<IProductDal, EfProductDal>();
			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<ICategoryDal, EfCategoryDal>();
			services.AddSingleton<ICartSessionService, CartSessionService>();
			services.AddSingleton<ICartService, CartService>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSession();
			services.AddDistributedMemoryCache();// sessionu elave edende bunu da elave elemek lazimdir

			services.AddMvc(op => op.EnableEndpointRouting = false);
			services.AddDbContext<CustomIdentityDbContext>(op => op.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;"));

			services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().
				AddEntityFrameworkStores<CustomIdentityDbContext>().
				AddDefaultTokenProviders();

			services.Configure<IdentityOptions>(op =>
			{
				op.Password.RequireLowercase = false;
				op.Password.RequireUppercase = false;
				op.Password.RequireNonAlphanumeric = false;
			}
			);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			//app.UseStaticFiles();
			app.UseStaticFiles();
			app.UseNodeModules(env.ContentRootPath);
			app.UseAuthentication();
			app.UseSession();// sessionun proyekte elave edilmesi
							 //app.UseMvc(ConfigureRoutes);
			app.UseMvcWithDefaultRoute();

		}

		private void ConfigureRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}");// sual isharesi optional demekdor
		}
	}
}
