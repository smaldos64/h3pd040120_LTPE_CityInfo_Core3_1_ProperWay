﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Entities;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Interfaces
{
    public interface ILanguageRepository : IRepositoryBase<Language>
    {
        // Filen her er kun medtaget for at åbne op for, at man kan placere "specielle"
        // funktioner vedrørende Language funktionalitet her. Ellers kan man styre det
        // hele med de generiske funktioner erklæret i IRepositiryBase.cs og implementeret i RepositoryBase.cs.

        //IEnumerable<Language> GetLanguages();

        //Language GetLanguage(int LanguageID);

        //IEnumerable<City> GetCitiesFromLanguages(int LanguageID);

        //void AddLanguage(Language language);

        //void UpdateLanguage(Language language);

        //void DeleteLanguage(Language language);

        //bool LanguageExists(int LanguageID);
    }
}
