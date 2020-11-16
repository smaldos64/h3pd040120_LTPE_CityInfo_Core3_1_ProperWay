﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Models
{
    public class CityDtoPointsOfInterests_Country
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

        public int CountryID { get; set; }

        public CountryDto Country { get; set; }
    }
}