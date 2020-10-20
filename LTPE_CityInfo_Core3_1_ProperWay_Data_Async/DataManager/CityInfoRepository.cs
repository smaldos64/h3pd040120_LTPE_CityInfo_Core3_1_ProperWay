using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Entities;
using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Context;
using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Interfaces;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.DataManager
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

        public async Task<IEnumerable<City>> GetAllCities(bool IncludeRelations = false)
        {
            if (false == IncludeRelations)
            {
                var collection = await (base.FindAll());
                collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(c => c.Name);
                return (collection);
            }
            else
            {
                //var collection = await base.RepositoryContext.Cities.
                //Include(c => c.PointsOfInterest).
                //Include(c => c.CityLanguages).
                //ThenInclude(l => l.Language) as IQueryable<City>;
                var collection = await base.RepositoryContext.Cities.
                Include(c => c.PointsOfInterest).
                Include(c => c.CityLanguages).
                ThenInclude(l => l.Language).ToListAsync();

                var collection1 = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(c => c.Name);
                return (collection1);
            }
        }

        public async Task<City> GetCity(int CityId, bool IncludeRelations = false)
        {
            if (false == IncludeRelations)
            {
                var City_Object = base.FindOne(CityId);
                return await City_Object;
            }
            else
            {
                //var City_Object = await base.FindAll().Where(c => c.Id == CityId).
                //Include(c => c.PointsOfInterest).
                //Include(c => c.CityLanguages).
                //ThenInclude(l => l.Language).
                //ToListAsync();

                //var City_Object1 = await base.FindOne(CityId).  Include(c => c.PointsOfInterest).
                //Include(c => c.CityLanguages).
                //ThenInclude(l => l.Language);

                var City_Object = await base.RepositoryContext.Cities.Include(c => c.PointsOfInterest).
                Include(c => c.CityLanguages).
                ThenInclude(l => l.Language).
                FirstOrDefaultAsync(c => c.Id == CityId);

                return (City_Object);
            }
        }

#if OLD_IMPLEMENTATION
        public IEnumerable<City> GetCitiesFromLanguages(int languageID)
        {
            return RepositoryContext.Cities.Include(x => x.CityLanguages).ThenInclude(x => x.Language).Include(x => x.PointsOfInterest).Where(x => x.CityLanguages.Any(cl => cl.LanguageId == languageID));
        }
#else
        public async Task<IEnumerable<City>> GetCitiesFromLanguageID(int languageID)
        {
            var collection = await base.FindByCondition(x => x.CityLanguages.Any(cl => cl.LanguageId == languageID));

            collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(c => c.Name);
            
            return (collection.ToList());
        }
#endif
    }
}
