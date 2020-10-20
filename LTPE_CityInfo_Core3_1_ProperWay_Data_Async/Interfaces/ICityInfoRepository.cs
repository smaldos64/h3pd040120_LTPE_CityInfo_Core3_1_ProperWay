using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Entities;


namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Interfaces
{
    public interface ICityInfoRepository : IRepositoryBase<City>
    {
        // De 3 metoder herunder er kun med for test formål. For at vise i 
        // CityController.cs hvordan man skal gøre for at få alle relationelle
        // data med, hvis man ikke har enabled lazy loading.
        Task<IEnumerable<City>> GetAllCities(bool IncludeRelations = false);

        Task<City> GetCity(int CityId, bool IncludeRelations = false);

        Task<IEnumerable<City>> GetCitiesFromLanguageID(int languageID);
    }
}
