using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Entities;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces
{
    public interface ILanguageRepository : IRepositoryBase<Language>
    {
        IEnumerable<Language> GetLanguages();

        Language GetLanguage(int LanguageID);

        IEnumerable<City> GetCitiesFromLanguages(int LanguageID);

        void AddLanguage(Language language);

        void UpdateLanguage(Language language);

        void DeleteLanguage(Language language);

        //bool Save();

        bool LanguageExists(int LanguageID);
    }
}
