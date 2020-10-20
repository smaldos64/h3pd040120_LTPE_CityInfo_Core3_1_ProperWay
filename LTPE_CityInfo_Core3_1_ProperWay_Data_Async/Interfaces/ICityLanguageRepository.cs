using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Entities;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Interfaces
{
    public interface ICityLanguageRepository : IRepositoryBase<CityLanguage>
    {
        #region From_CityLanguage
        Task<IEnumerable<CityLanguage>> GetAllCitiesLanguages();

        Task<IEnumerable<CityLanguage>> GetAllCitiesFromLanguageID(int LanguageID);

        Task<IEnumerable<CityLanguage>> GetAllLanguagesFromCityID(int CityID);

        Task AddCityLanguage(CityLanguage cityLanguage);

        Task<IEnumerable<CityLanguage>> GetAllCitiesWithLanguageID(int LanguageID);

        #endregion
    }
}
