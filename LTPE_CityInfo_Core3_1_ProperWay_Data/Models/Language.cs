using AutoMapper;
using LTPE_CityInfo_Core3_1_ProperWay_Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Models
{
    // Database model
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string LanguageName { get; set; }

        public virtual ICollection<CityLanguage> CityLanguages { get; set; }
               = new List<CityLanguage>();
    }

    // DTO modeller
    public class LanguageForUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public virtual string LanguageName { get; set; }
    }
    
    public class LanguageDtoMinusRelations : LanguageForUpdateDto
    {
        public int Id { get; set; }
    }

    public class LanguageDto : LanguageDtoMinusRelations
    {
        public ICollection<CityDtoPointsOfInterests_Country> CityLanguages { get; set; }
              = new List<CityDtoPointsOfInterests_Country>();
    }

    // Automapper Profiler
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            // CreateMap<source, destination>()
            CreateMap<LanguageDto, Models.Language>();

            // LTPE new !!!
            CreateMap<Models.Language, LanguageDtoMinusRelations>();
            CreateMap<LanguageDtoMinusRelations, Models.Language>();

            // LTPE Below
            CreateMap<Models.Language, LanguageDto>()
                .ForMember(
                dest => dest.CityLanguages,
                opt => opt.MapFrom(src => src.CityLanguages.Select(x => x.City)));
            // Nødvendig med .ForMember direktivet herover, selvom navnet på vores Source 
            // model Entities.Language (CityLanguages) er det samme som navnet på vores Destination model
            // Models.LanguageDto (CityLanguages). Dette skal med, når vi arbejder med mange-til-mange
            // relationer og vi "angriber" fra en af de ydre tabeller => ikke samlingstabellen !!! 

            // Models er vores Database model.
            // DTO er vores præsentations model
        }
    }
}
