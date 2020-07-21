using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using LTPE_CityInfo_Core3_1_ProperWay_WebApi.Extensions;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi
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
            //services.AddControllers();

            //var connectionString = Configuration["connectionStrings:cityInfoDBConnectionString"];
            //services.AddDbContext<CityInfoContext>(o =>
            //{
            //    o.UseSqlServer(connectionString, b => b.MigrationsAssembly("LTPE_CityInfoCore3_1_ProperWay_WebApi"));
            //});
            services.ConfigureSqlContext(Configuration);

            services.ConfigureRepositoryWrapper();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
