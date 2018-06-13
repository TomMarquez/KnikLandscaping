using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnikLandscaping.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KnikLandscaping
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        //private IHostingEnvironment _env;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //_env = env;

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(_env.ContentRootPath)
            //    .AddJsonFile("config.json")
            //    .AddEnvironmentVariables();

            //configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddLogging();

            services.AddDbContext<KinkLandscapingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("KnikLandscapingConnection")));

            services.AddTransient<KnikLandScapingSeedData>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            KnikLandScapingSeedData seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //searches www.root file
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            seeder.EnsureSeedData().Wait();
        }
    }
}
