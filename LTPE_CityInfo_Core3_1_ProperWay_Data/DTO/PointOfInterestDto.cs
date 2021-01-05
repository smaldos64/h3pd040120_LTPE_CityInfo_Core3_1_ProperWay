using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DTO
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }

    public class PointOfInterestDto : PointOfInterestForUpdateDto
    {
        public int Id { get; set; }
      
        public int CityID { get; set; }
        // Navigation Property => ingen grund til at have dette felt med i vores
        // DTO model !!!
    }
}
