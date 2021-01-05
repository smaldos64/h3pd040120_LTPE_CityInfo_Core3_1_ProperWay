using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.DTO;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles
{
    public class CityLanguageProfile : Profile
    {
        public CityLanguageProfile()
        {
            // CreateMap<source, destination>()
            CreateMap<CityLanguage, CityLanguageDto>();

            CreateMap<CityLanguageDto, CityLanguage>();

            CreateMap<CityLanguage, CityLanguageWithoutRelationsDto>();
        }
    }
}
