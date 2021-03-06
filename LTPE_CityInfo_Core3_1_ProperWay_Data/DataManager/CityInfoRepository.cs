﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Context;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DataManager
{
    public class CityInfoRepository : RepositoryBase<City>, ICityInfoRepository
    {
        public CityInfoRepository(CityInfoContext context) : base(context)
        {
            if (null == context)
            {
                throw new ArgumentNullException(nameof(context));
            }
            this.RepositoryContext.ChangeTracker.LazyLoadingEnabled = false;
        }

        public IEnumerable<City> GetAllCities(bool IncludeRelations = false)
        {
            if (false == IncludeRelations)
            {
                var collection = (base.FindAll());
                collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(c => c.Name);
                return (collection);
            }
            else
            {
                var collection = base.RepositoryContext.Cities.
                Include(c => c.PointsOfInterest).
                Include(c => c.CityLanguages).
                ThenInclude(l => l.Language) as IQueryable<City>;

                collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(c => c.Name);
                return (collection);
            }
        }

        public City GetCity(int CityId, bool IncludeRelations = false)
        {
            if (false == IncludeRelations)
            {
                var City_Object = base.FindOne(CityId);
                return (City_Object);
            }
            else
            {
                var City_Object = base.FindAll().Where(c => c.Id == CityId).
                Include(c => c.PointsOfInterest).
                Include(c => c.CityLanguages).
                ThenInclude(l => l.Language).
                FirstOrDefault();

                return (City_Object);
            }
        }

#if OLD_IMPLEMENTATION
        public IEnumerable<City> GetCitiesFromLanguages(int languageID)
        {
            return RepositoryContext.Cities.Include(x => x.CityLanguages).ThenInclude(x => x.Language).Include(x => x.PointsOfInterest).Where(x => x.CityLanguages.Any(cl => cl.LanguageId == languageID));
        }
#else
        public IEnumerable<City> GetCitiesFromLanguageID(int languageID)
        {
            var collection = base.FindByCondition(x => x.CityLanguages.Any(cl => cl.LanguageId == languageID));

            collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(c => c.Name);
            
            return (collection.ToList());
        }
#endif
    }
}
