using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Entities.Country, Models.CountryDto>();
        }
    }
}
