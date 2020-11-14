using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpeedDating.Web.Core;
using SpeedDating.Web.Services;

namespace SpeedDating.Web
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", config =>
                {
                    config.Cookie.Name = "SpeedDating.User.Cookie";
                    config.LoginPath = "/User/Login";
                });

            services.AddDbContext<ObjectContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            

            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDbContext, ObjectContext>();
            services.AddScoped<IWorkContext, WorkContext>();
            services.AddScoped<IWoocommerceService, WoocommerceService>();




            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddControllersWithViews();
            //services.AddControllers(options => options.EnableEndpointRouting = false);
            //services.AddMvc(options => options.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();

            
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "areaRoute", template: "{area}/{controller=User}/{action=Login}/{id?}");
            //    routes.MapRoute(
            //       name: "default",
            //       template: "{controller=User}/{action=Login}/{id?}");

            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                   "areas",
                   pattern: "{area}/{controller=User}/{action=Dashboard}/{id?}");

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
