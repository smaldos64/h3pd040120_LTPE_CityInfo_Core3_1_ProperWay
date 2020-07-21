using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Entities;


namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces
{
    public interface ICityInfoRepository : IRepositoryBase<City>
    {
        /*#region From_CitiesLazyLoad
        IEnumerable<City> GetCitiesAdvancedLazyLoad();
        #endregion

        #region From_Cities1Controller
        IEnumerable<City> GetCitiesAdvanced();
        City GetCityAdvanced(int cityId,
                             bool includePointsOfInterest = false,
                             bool includeLanguages = false);

        void AddCity(City city);

        void UpdateCity(City city);

        void DeleteCity(City city);
        #endregion

        #region From_CitiesController_And_PointOfIntererstController
        IEnumerable<City> GetCities();
        
        City GetCity(int cityId, bool includePointsOfInterest);
        
        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);

        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);

        bool CityExists(int cityId);

        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        #endregion

        #region General
        //bool Save();
        #endregion*/
    }
}
