using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Profiles
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
            //CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>(); LTPE
            CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>()
                .ReverseMap();

            // Ovennævnte syntaks er en kortere form af de 2 syntakser herunder. 
            // Den er god at anvende her, da det ses herunder, at de 2 linjer kode her
            // er hinandens reverse.
            //CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>();
            //CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
        }
    }
}
