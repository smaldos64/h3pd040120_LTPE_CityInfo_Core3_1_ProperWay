//#define USE_LAZY_LOADING

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Entities;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Context
{
    public class CityInfoContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<CityLanguage> CityLanguages { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options,
                               IConfiguration config)
           : base(options)
        {
            this._configuration = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityLanguage>()
                .HasKey(cl => new
                {
                     cl.CityId,
                     cl.LanguageId
                });
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if ENABLED_FOR_LAZY_LOADING_USAGE
            string connectionString = this._configuration.GetConnectionString("cityInfoDBConnectionString");
            
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
#endif
        }

    }
}
