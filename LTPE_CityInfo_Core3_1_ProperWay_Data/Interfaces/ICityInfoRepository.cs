using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Entities;


namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces
{
    public interface ICityInfoRepository : IRepositoryBase<City>
    {
        public IEnumerable<City> GetAllCities(bool IncludeRelations = false);
        //public IEnumerable<City> GetAllCities();
    }
}
