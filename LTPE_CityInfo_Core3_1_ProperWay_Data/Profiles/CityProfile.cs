using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            // CreateMap<source, destination>()
            CreateMap<Entities.City, Models.CityDtoMinusRelations>();
            CreateMap<Entities.City, Models.CityDtoPointsOfInterests_Country>();

            CreateMap<Entities.City, Models.CityDto>()
                .ForMember(
                dest => dest.CityLanguages,
                opt => opt.MapFrom(src => src.CityLanguages.Select(x => x.Language)));
            // Nødvendig med .ForMember direktivet herover, selvom navnet på vores Source 
            // model Entities.City (CityLanguages) er det samme som navnet på vores Destination model
            // Models.CityDto (CityLanguages). Dette skal med, når vi arbejder med mange-til-mange
            // relationer og vi "angriber" fra en af de ydre tabeller => ikke samlingstabellen !!! 
            
            // Entities er vores Database model.
            // Models er vores præsentations model

            CreateMap<Models.CityForUpdateDto, Entities.City>()
                .ReverseMap();
        }
    }
}
