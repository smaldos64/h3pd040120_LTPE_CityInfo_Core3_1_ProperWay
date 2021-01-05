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

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Mapster;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.DTO;

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
            services.ConfigureSqlContext(Configuration);

            services.ConfigureRepositoryWrapper();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // LTPE
            // Koden herunder bør ikke være nødvendig i et ordentligt
            // struktureret projekt. Den er medtaget her for at give 
            // mulighed for at vise, hvor meget cyklisk data man kan få sendt
            // tilbage til en klient, hvis man bare tager alt data med !!!
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Formatting = Formatting.Indented;
            });
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            //TypeAdapterConfig<City, CityDto>.NewConfig().Map(dest => dest.Name, src => src.Name);
            TypeAdapterConfig<City, CityDto>.NewConfig().Map(dest => dest.CityLanguages, src => src.CityLanguages.Select(x => x.Language));

            //CreateMap<City, CityDto>()
            //    .ForMember(
            //    dest => dest.CityLanguages,
            //    opt => opt.MapFrom(src => src.CityLanguages.Select(x => x.Language)));

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
