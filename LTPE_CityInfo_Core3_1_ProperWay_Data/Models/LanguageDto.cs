﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Models
{
    public class LanguageDto
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }

        //public ICollection<CityLanguageDto> CityLanguages { get; set; }
        //       = new List<CityLanguageDto>();

        public ICollection<CityDto> CityLanguages { get; set; }
              = new List<CityDto>();
    }
}
