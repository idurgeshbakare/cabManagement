using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.CabLocator;
using CabManagement.Managers;
using CabManagement.Managers.Impl;
using CabManagement.Services;
using CabManagement.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CabManagement
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Managers
            services.AddTransient<ICabManager, CabManager>();
            services.AddTransient<IBookingManager, BookingManager>();
            services.AddTransient<IRiderManager, RiderManager>();
            

            // Services
            services.AddTransient<ICabService, CabService>();
            services.AddTransient<ITripService, TripService>();
            services.AddTransient<IRiderService, RiderService>();
            services.AddTransient<ICabLocatorStrategy, CabLocatorByIdlTimeStrategy>(); 

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
