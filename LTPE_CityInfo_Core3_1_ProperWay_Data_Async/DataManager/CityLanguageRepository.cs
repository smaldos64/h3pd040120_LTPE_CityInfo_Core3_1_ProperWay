using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Entities;
using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Context;
using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Interfaces;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.DataManager
{
    public class CityLanguageRepository : RepositoryBase<CityLanguage>, ICityLanguageRepository
    {
        #region General
        private readonly CityInfoContext _context;

        public CityLanguageRepository(CityInfoContext context) : base(context) 
        { 
           _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion

        #region From_CityLanguage
        public async Task<IEnumerable<CityLanguage>> GetAllCitiesLanguages()
        {
            var collection = await base.RepositoryContext.CityLanguages.
                Include(c => c.City).
                Include(l => l.Language).ToListAsync();

            var collection1 = collection.OrderByDescending(c => c.City.CityLanguages.Count);
            
            return collection1;
        }

        public async Task<IEnumerable<CityLanguage>> GetAllCitiesFromLanguageID(int LanguageID)
        {
            var collection = await _context.CityLanguages.Where(l => l.LanguageId == LanguageID).ToListAsync();
               
            var collection1 = collection.OrderByDescending(c => c.City.CityLanguages.Count);

            return collection1;
        }

        public async Task<IEnumerable<CityLanguage>> GetAllLanguagesFromCityID(int CityID)
        {
            var collection = await _context.CityLanguages.Where(c => c.CityId == CityID).
                Include(c => c.City).
                Include(l => l.Language).ToListAsync();
                
            var collection1 = collection.OrderByDescending(l => l.Language.CityLanguages.Count);

            return collection1;
        }

        public async Task AddCityLanguage(CityLanguage cityLanguage)
        {
            await _context.CityLanguages.AddAsync(cityLanguage);
        }

        // Kode fra nyt generisk interface herunder.
        public async Task<IEnumerable<CityLanguage>> GetAllCitiesWithLanguageID(int LanguageID)
        {
            var collection = await base.FindByCondition(l => l.LanguageId == LanguageID);
            collection = collection.OrderByDescending(l => l.Language.CityLanguages.Count).ThenBy(c => c.City.Name);
            
            return (collection.ToList());
        }
        #endregion
    }
}
