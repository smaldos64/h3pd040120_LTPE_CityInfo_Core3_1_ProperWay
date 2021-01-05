using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DTO
{

    public class CityLanguageForUpdateDto
    {
        public int CityId { get; set; }

        public int LanguageId { get; set; }
    }
    
    public class CityLanguageWithoutRelationsDto : CityLanguageForUpdateDto
    {
    }

    public class CityLanguageDto : CityLanguageWithoutRelationsDto
    {
        public CityDtoPointsOfInterests_Country City { get; set; }

        public LanguageDtoMinusRelations Language { get; set; }
    }
}
