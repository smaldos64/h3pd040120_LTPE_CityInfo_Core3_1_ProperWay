﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Context;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DataManager
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
        public IEnumerable<CityLanguage> GetAllCitiesLanguages(bool IncludeRelations = false)
        {
            if (false == IncludeRelations)
            {
                var collection = (base.FindAll());
                collection = collection.OrderByDescending(c => c.City.CityLanguages.Count);
                return (collection);
            }
            else
            {
                //var collection = _context.CityLanguages.
                base.DisableLazyLoading();
                var collection = base.FindAll().
                    Include(c => c.City).
                    ThenInclude(p => p.PointsOfInterest).
                    Include(c => c.City).           
                    ThenInclude(co => co.Country).  
                    Include(l => l.Language)
                    as IQueryable<CityLanguage>;

                collection = collection.OrderByDescending(c => c.City.CityLanguages.Count);

                return collection.ToList();
            }
        }

        public IEnumerable<CityLanguage> GetAllCitiesFromLanguageID(int LanguageID)
        {
            var collection = _context.CityLanguages.Where(l => l.LanguageId == LanguageID)
                as IQueryable<CityLanguage>;

            collection = collection.OrderByDescending(c => c.City.CityLanguages.Count);

            return collection.ToList();
        }

        public IEnumerable<CityLanguage> GetAllLanguagesFromCityID(int CityID)
        {
            var collection = _context.CityLanguages.Where(c => c.CityId == CityID).
                Include(c => c.City).
                Include(l => l.Language)
                as IQueryable<CityLanguage>;

            collection = collection.OrderByDescending(l => l.Language.CityLanguages.Count);

            return collection.ToList();
        }

        public void AddCityLanguage(CityLanguage cityLanguage)
        {
            _context.CityLanguages.Add(cityLanguage);
        }

        // Kode fra nyt generisk interface herunder.
        public IEnumerable<CityLanguage> GetAllCitiesWithLanguageID(int LanguageID)
        {
            var collection = base.FindByCondition(l => l.LanguageId == LanguageID);
            collection = collection.OrderByDescending(l => l.Language.CityLanguages.Count).ThenBy(c => c.City.Name);
            
            return (collection.ToList());
        }
        #endregion
    }
}
