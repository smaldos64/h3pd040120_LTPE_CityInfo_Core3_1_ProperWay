using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Entities
{
    public class CityLanguage
    {
        [Required]
        [Key]
        public int CityId { get; set; }
     
        [Required]
        [Key]
        public int LanguageId { get; set; }

        public virtual City City { get; set; }

        public virtual Language Language { get; set; }
    }
}
