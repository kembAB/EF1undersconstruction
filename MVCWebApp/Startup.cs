using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MVCWebApp.EFwk;
using MVCWebApp.Models.Home;
using MVCWebApp.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data ;
namespace MVCWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession(options =>
            {
                options.IOTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();

            services.AddMvc();
            ////configuration with getconnection string not working 
            //services.AddDbContext<personSeedDbContext>(
            //  options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //
      
        
            //
            services.AddScoped<IgithubProjectsRepository, githubprojects>(); //add repository
            services.AddSingleton<Iperson, Personpopulate>(); //add repository
            services.AddHttpContextAccessor();
            services.AddSession();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //.AddJsonFile("appsettings.json")
        //.Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //    }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.



        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           // app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            //C:\Users\haile\source\repos\MVCBasicsAssignment2
            app.UseEndpoints(endpoints =>
            {
                
                //Default route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                // example test route  :/FeverCheck/12
                endpoints.MapControllerRoute(
                         name: "Doctor",
                         pattern: "FeverCheck/{patientTemp:maxlength(10)}",
                         defaults: new { controller = "Doctor", action = "FeverCheck"});

                //GuessingGame test  route :/GuessingGame/Index
                endpoints.MapControllerRoute(
                    name: "GuessingGame",
                    pattern: "GuessingGame/EnteredNum:maxlength(101)",
                    defaults: new { controller = "GuessingGame", action = "Index" });

                //Person route
                endpoints.MapControllerRoute(
                    name: "Personlist",
                    pattern: "Personlist",
                    defaults: new { controller = "Person", action = "Index" });

                //AjaxPerson route
                endpoints.MapControllerRoute(
                    name: "Personlist",
                    pattern: "Personlist",
                    defaults: new { controller = "AjaxController", action = "Index" });
            });

        }
    }
}
