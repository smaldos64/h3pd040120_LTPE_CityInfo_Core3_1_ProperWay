using System;
using System.Collections.Generic;
using System.Text;

//using LTPE_CityInfo_Core3

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICityInfoRepository CityInfoRepositoryWrapper { get; }

        ICityLanguageRepository CityLanguageRepositoryWrapper { get; }

        ILanguageRepository LanguageRepositoryWrapper { get; }

        void Save();

    }
}
