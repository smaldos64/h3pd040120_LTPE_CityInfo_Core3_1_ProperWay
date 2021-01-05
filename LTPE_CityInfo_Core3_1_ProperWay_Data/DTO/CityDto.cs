using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DTO
{
    public class CityForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }

    public class CityDtoMinusRelations : CityForUpdateDto
    {
        public int Id { get; set; }
    }

    public class CityDtoPointsOfInterests_Country : CityDtoMinusRelations
    {
        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
          = new List<PointOfInterestDto>();

        public int CountryID { get; set; }

        public CountryDto Country { get; set; }
    }

    public class CityDto : CityDtoPointsOfInterests_Country
    {
        public ICollection<LanguageDtoMinusRelations> CityLanguages { get; set; }
               = new List<LanguageDtoMinusRelations>();
    }
}
