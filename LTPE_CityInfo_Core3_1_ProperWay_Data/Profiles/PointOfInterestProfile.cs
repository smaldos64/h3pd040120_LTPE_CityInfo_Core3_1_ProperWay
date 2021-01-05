using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.DTO;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<PointOfInterest, PointOfInterestDto>();
            CreateMap<PointOfInterestForUpdateDto, PointOfInterest>()
                .ReverseMap();

            // Ovennævnte syntaks er en kortere form af de 2 syntakser herunder. 
            // Den er god at anvende her, da det ses herunder, at de 2 linjer kode her
            // er hinandens reverse.
            //CreateMap<PointOfInterest, PointOfInterestForUpdateDto>();
            //CreateMap<PointOfInterestForUpdateDto, PointOfInterest>();

            // Models er vores Database model.
            // DTO er vores præsentations model
        }
    }
}
