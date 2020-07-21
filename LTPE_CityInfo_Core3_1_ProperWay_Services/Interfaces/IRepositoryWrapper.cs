using System;
using System.Collections.Generic;
using System.Text;

//using LTPE_CityInfo_Core3

namespace LTPE_CityInfo_Core3_1_ProperWay_Services.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICityInfoRepository CityInfoRepository { get; }

        ICityLanguageRepository CityLanguageRepository { get; }

    }
}
