

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            // CreateMap<source, destination>()
            //CreateMap<Entities.Language, Models.LanguageDto>();
            CreateMap<Models.LanguageDto, Entities.Language>();

            // LTPE new !!!
            CreateMap<Entities.Language, Models.LanguageDtoMinusRelations>();
            CreateMap<Models.LanguageDtoMinusRelations, Entities.Language>();

            //CreateMap<Models.LanguageOfCreation, Entities.Language>(); // LTPE
            //CreateMap<Models.LanguageOfUpdate, Entities.Language>(); // LTPE
            //CreateMap<Entities.Language, Models.LanguageOfUpdate>(); // LTPE

            // LTPE Below
            CreateMap<Entities.Language, Models.LanguageDto>()
                .ForMember(
                dest => dest.CityLanguages,
                opt => opt.MapFrom(src => src.CityLanguages.Select(x => x.City)));
            // Nødvendig med .ForMember direktivet herover, selvom navnet på vores Source 
            // model Entities.Language (CityLanguages) er det samme som navnet på vores Destination model
            // Models.LanguageDto (CityLanguages). Dette skal med, når vi arbejder med mange-til-mange
            // relationer og vi "angriber" fra en af de ydre tabeller => ikke samlingstabellen !!! 

            // Entities er vores Database model.
            // Models er vores præsentations model
        }
    }
}
