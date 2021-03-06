﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using AutoMapper.Configuration;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;
using LTPE_CityInfo_Core3_1_ProperWay_Data.DataManager;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Context;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["connectionStrings:cityInfoDBConnectionString"];
            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
