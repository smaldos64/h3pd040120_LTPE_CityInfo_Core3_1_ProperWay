using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.DTO;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>();

            // Models er vores Database model.
            // DTO er vores præsentations model
        }
    }
}
