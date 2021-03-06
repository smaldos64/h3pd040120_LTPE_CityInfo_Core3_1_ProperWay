﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces
{
    public interface ICityLanguageRepository : IRepositoryBase<CityLanguage>
    {
        #region From_CityLanguage
        IEnumerable<CityLanguage> GetAllCitiesLanguages(bool IncludeRelations = false);

        IEnumerable<CityLanguage> GetAllCitiesFromLanguageID(int LanguageID);

        IEnumerable<CityLanguage> GetAllLanguagesFromCityID(int CityID);

        void AddCityLanguage(CityLanguage cityLanguage);

        public IEnumerable<CityLanguage> GetAllCitiesWithLanguageID(int LanguageID);

        #endregion
    }
}
