using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
          = new List<PointOfInterestDto>();

        public ICollection<LanguageDtoMinusRelations> CityLanguages { get; set; }
               = new List<LanguageDtoMinusRelations>();

        //public ICollection<LanguageDto> CityLanguages { get; set; }
        //       = new List<LanguageDto>();
    }
}
