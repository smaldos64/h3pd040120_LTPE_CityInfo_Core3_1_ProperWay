using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Models
{
    public class LanguageOfManipulation
    {
        [Required]
        public virtual string Name { get; set; }
    }
}
