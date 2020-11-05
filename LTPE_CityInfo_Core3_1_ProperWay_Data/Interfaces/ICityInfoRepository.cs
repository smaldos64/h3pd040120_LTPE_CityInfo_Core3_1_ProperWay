using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Entities;


namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces
{
    public interface ICityInfoRepository : IRepositoryBase<City>
    {
        // De 3 metoder herunder er kun med for test formål. For at vise i 
        // CityController.cs hvordan man skal gøre for at få alle relationelle
        // data med, hvis man ikke har enabled lazy loading.
        public IEnumerable<City> GetAllCities(bool IncludeRelations = false);

        public City GetCity(int CityId, bool IncludeRelations = false);

        public IEnumerable<City> GetCitiesFromLanguageID(int languageID);
    }
}
