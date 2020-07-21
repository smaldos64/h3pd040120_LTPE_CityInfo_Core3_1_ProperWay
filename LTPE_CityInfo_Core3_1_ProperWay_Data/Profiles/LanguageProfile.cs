

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            // CreateMap<source, destination>()
            CreateMap<Entities.Language, Models.LanguageDto>();

            CreateMap<Models.LanguageDto, Entities.Language>();

            CreateMap<Models.LanguageOfCreation, Entities.Language>();
            CreateMap<Models.LanguageOfUpdate, Entities.Language>();
            CreateMap<Entities.Language, Models.LanguageOfUpdate>();
        }
    }
}
