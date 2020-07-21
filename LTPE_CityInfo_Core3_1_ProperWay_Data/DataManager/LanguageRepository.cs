using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Entities;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Context;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DataManager
{
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        private readonly CityInfoContext _context;

        public LanguageRepository(CityInfoContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Language> GetLanguages()
        {
            var collection = _context.Languages.
                Include(l => l.CityLanguages).
                ThenInclude(c => c.City) as IQueryable<Language>;

            collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(l => l.LanguageName);

            return collection.ToList();
        }

        public IEnumerable<City> GetCitiesFromLanguages(int LanguageID)
        {
            var collection = _context.Cities.
                Include(c => c.CityLanguages).
                ThenInclude(l => l.Language).
                Where(c => c.CityLanguages.Any(l => l.LanguageId == LanguageID))
                as IQueryable<City>;

            //collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(l => l.LanguageName);

            return collection.ToList();
        }

        public Language GetLanguage(int LanguageID)
        {
            return (_context.Languages.Find(LanguageID));
        }

        public void AddLanguage(Language language)
        {
            _context.Languages.Add(language);
        }

        public void UpdateLanguage(Language language)
        {
            // I andre implementatiober af ICityRepository skal der muligvis adderes kode
            // her for at få gemt opdaterede Cities.
        }

        public void DeleteLanguage(Language language)
        {
            _context.Languages.Remove(language);
        }

        //public bool Save()
        //{
        //    return (_context.SaveChanges() >= 0);
        //}

        public bool LanguageExists(int LanguageID)
        {
            if (null != _context.Languages.Find(LanguageID))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}
