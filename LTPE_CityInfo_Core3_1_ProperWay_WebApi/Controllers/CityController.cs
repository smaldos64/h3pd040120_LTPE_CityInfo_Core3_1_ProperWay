//#define Use_Lazy_Loading_On_City_Controller
//#define Show_Loaded_Trash_Data
//#define Show_Empty_Related_Date_Fields

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;
//using LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Entities;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi.Controllers
{
    public class CityControllerParameters
    {
        // De 4 parametre herunder bestemmer hvordan output data fra controlleren her
        // præsenteres og behandles for klienten. 
        // Parameterne er medtaget først og fremmest af uddennelsesmæssige
        // formål, således at brugerne af controlleren her, kan se
        // hvordan man kan returnere (relationelle) data på forskellige måder fra en 
        // controller tilbage til en klient.

        public bool _use_Lazy_Loading_On_City_Controller = true;
        public bool _show_Cyclic_Data = false;
        public bool _show_Empty_Related_Date_Fields = false;
        public bool _use_AutoMapper = true;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private static CityControllerParameters _cityControllerParameters_Object = new CityControllerParameters();

        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        public CityController(IRepositoryWrapper repositoryWrapper,
                              IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities(bool includeRelations = false)
        {
            if (false == includeRelations)
            {
                _repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();
            }
            else  // true == includeRelations 
            {
                _repositoryWrapper.CityInfoRepositoryWrapper.EnableLazyLoading();
            }

            var cityEntities = _repositoryWrapper.CityInfoRepositoryWrapper.FindAll();

            // Koden der er udkommenteret herunder er med for at vise, at man kan nå alle
            // wrappere fra alle controllers. 
            //var LanguageEntities = _repositoryWrapper.LanguageRepositoryWrapper.FindAll();

            var CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);

            return Ok(CityDtos);
        }

        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(int id, bool includeRelations = false)
        {
            if (false == includeRelations)
            {
                _repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();
            }
            else
            {
                _repositoryWrapper.CityInfoRepositoryWrapper.EnableLazyLoading();
            }

            var cityEntity = _repositoryWrapper.CityInfoRepositoryWrapper.FindOne(id);

            if (null == cityEntity)
            {
                return NotFound();
            }
            else
            {
                CityDto CityDto_Object = _mapper.Map<CityDto>(cityEntity);
                return Ok(CityDto_Object);
            }
        }

        // Metoden herunder er "kun" medtaget for test formål. Den bruges til at vise
        // hvordan data fra controlleren kan formatteres på forskellig måde.
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCitiesDataTest(bool includeRelations = false)
        {
            if (_cityControllerParameters_Object._use_Lazy_Loading_On_City_Controller)
            {
                if (false == includeRelations)
                {
                    _repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

                    var cityEntities = _repositoryWrapper.CityInfoRepositoryWrapper.FindAll();

                    if (_cityControllerParameters_Object._show_Empty_Related_Date_Fields)
                    {
                        var CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);
                        return Ok(CityDtos);
                    }
                    else
                    {
                        var CityDtos = _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);
                        return Ok(CityDtos);
                    }
                }
                else  // true == includeRelations 
                {
                    _repositoryWrapper.CityInfoRepositoryWrapper.EnableLazyLoading();

                    var cityEntities = _repositoryWrapper.CityInfoRepositoryWrapper.FindAll();

                    if (false == _cityControllerParameters_Object._use_AutoMapper)
                    {
                        // Her vises den kode, der i praksis udføres generisk ved brug af AutoMapper !!!
                        IEnumerable<CityDto> CityDtos = MapHere(cityEntities.ToList());
                        return Ok(CityDtos);
                    }
                    else
                    {
                        IEnumerable<CityDto> CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);

                        if (_cityControllerParameters_Object._show_Cyclic_Data)
                        {
                            return Ok(cityEntities);
                        }
                        else
                        {
                            return Ok(CityDtos);
                        }
                    }
                }
            }
            else  // !_use_Lazy_Loading_On_City_Controller
            {
                _repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

                if (false == includeRelations)
                {
                    var cityEntities = _repositoryWrapper.CityInfoRepositoryWrapper.GetAllCities(includeRelations);

                    if (_cityControllerParameters_Object._show_Empty_Related_Date_Fields)
                    {
                        var CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);
                        return Ok(CityDtos);
                    }
                    else
                    {
                        var CityDtos = _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);
                        return Ok(CityDtos);
                    }
                }
                else  // true == includeRelations 
                {
                    //var cityEntities = _repositoryWrapper.CityInfoRepositoryWrapper.FindByCondition(c => c.Id == c.Id);
                    var cityEntities = _repositoryWrapper.CityInfoRepositoryWrapper.GetAllCities(includeRelations);
                    IEnumerable<CityDto> CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);

                    if (_cityControllerParameters_Object._show_Cyclic_Data)
                    {
                        return Ok(cityEntities);
                    }
                    else
                    {
                        return Ok(CityDtos);
                    }
                }
            }
        }

        // Metoden herunder er "kun" medtaget for test formål. Den bruges til at vise
        // hvordan data fra controlleren kan formatteres på forskellig måde.
        [HttpGet("GetCityDataTest/{id}")]
        //[Route("[action]")]
        public IActionResult GetCityDataTest(int id, bool includeRelations = false)
        {
            if (_cityControllerParameters_Object._use_Lazy_Loading_On_City_Controller)
            {
                if (false == includeRelations)
                {
                    _repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

                    var cityEntity = _repositoryWrapper.CityInfoRepositoryWrapper.FindOne(id);

                    if (null == cityEntity)
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (_cityControllerParameters_Object._show_Empty_Related_Date_Fields)
                        {
                            CityDto CityDto_Object = _mapper.Map<CityDto>(cityEntity);
                            return Ok(CityDto_Object);
                        }
                        else
                        {
                            CityWithoutPointsOfInterestDto CityDto_Object = _mapper.Map<CityWithoutPointsOfInterestDto>(cityEntity);
                            return Ok(CityDto_Object);
                        }
                    }
                }
                else  // true == includeRelations
                {
                    _repositoryWrapper.CityInfoRepositoryWrapper.EnableLazyLoading();

                    var cityEntity = _repositoryWrapper.CityInfoRepositoryWrapper.FindOne(id);

                    if (null == cityEntity)
                    {
                        return NotFound();
                    }
                    else
                    {
                        CityDto CityDto_Object = _mapper.Map<CityDto>(cityEntity);
                        if (_cityControllerParameters_Object._show_Cyclic_Data)
                        {
                            return Ok(cityEntity);
                        }
                        else
                        {
                            return Ok(CityDto_Object);
                        }
                    }
                }
            }
            else  // !_use_Lazy_Loading_On_City_Controller
            {
                _repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

                if (false == includeRelations)
                {
                    var cityEntity = _repositoryWrapper.CityInfoRepositoryWrapper.GetCity(id, includeRelations);

                    if (null == cityEntity)
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (_cityControllerParameters_Object._show_Empty_Related_Date_Fields)
                        {
                            var CityDto_Object = _mapper.Map<CityDto>(cityEntity);
                            return Ok(CityDto_Object);
                        }
                        else
                        {
                            var CityDto_Object = _mapper.Map<CityWithoutPointsOfInterestDto>(cityEntity);
                            return Ok(CityDto_Object);
                        }
                    }
                }
                else  // true == includeRelations 
                {
                    var cityEntity = _repositoryWrapper.CityInfoRepositoryWrapper.GetCity(id, includeRelations);

                    if (null == cityEntity)
                    {
                        return NotFound();
                    }
                    else
                    {
                        CityDto CityDto_Object = _mapper.Map<CityDto>(cityEntity);

                        if (_cityControllerParameters_Object._show_Cyclic_Data)
                        {
                            return Ok(cityEntity);
                        }
                        else
                        {
                            return Ok(CityDto_Object);
                        }
                    }
                }
            }
        }

        // POST: api/City
        [HttpPost]
        public IActionResult CreateCity([FromBody] City city)
        {
            if (city.Description == city.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different from the name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repositoryWrapper.CityInfoRepositoryWrapper.Create(city);
            //_repositoryWrapper.CityInfoRepositoryWrapper.Save();

            return Ok(city.Id);
        }

        // POST: api/Controller Parameters
        [HttpPost]
        [Route("[action]")]
        public IActionResult PostControllerSettingParameters(bool Use_Lazy_Loading_On_City_Controller = true,
                                                             bool Show_Cyclic_Data = false,
                                                             bool Show_Empty_Related_Date_Fields = false,
                                                             bool Use_AutoMapper = true)
        {
            _cityControllerParameters_Object._use_Lazy_Loading_On_City_Controller = Use_Lazy_Loading_On_City_Controller;
            _cityControllerParameters_Object._show_Cyclic_Data = Show_Cyclic_Data;
            _cityControllerParameters_Object._show_Empty_Related_Date_Fields = Show_Empty_Related_Date_Fields;
            _cityControllerParameters_Object._use_AutoMapper = Use_AutoMapper;

            return Ok(_cityControllerParameters_Object);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] CityForUpdateDto city)
        {
            if (city.Description == city.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different from the name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

            var cityFromRepo = _repositoryWrapper.CityInfoRepositoryWrapper.FindOne(id);

            if (null == cityFromRepo)
            {
                return NotFound();
            }

            _mapper.Map(city, cityFromRepo);

            _repositoryWrapper.CityInfoRepositoryWrapper.Update(cityFromRepo);
            //_repositoryWrapper.CityInfoRepositoryWrapper.Save();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            _repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

            var cityFromRepo = _repositoryWrapper.CityInfoRepositoryWrapper.FindOne(id);

            if (null == cityFromRepo)
            {
                return NotFound();
            }

            _repositoryWrapper.CityInfoRepositoryWrapper.Delete(cityFromRepo);

            //_mailService.Send("City deleted.",
            //        $"City {cityEntity.Name} with id {cityEntity.Id} was deleted.");

            return NoContent();
        }

        public List<CityDto> MapHere(List<City> Cities)
        {
            //List<CityDto> CityDtos = new List<CityDto>();
            ////ICollection<CityDto> CityDtosI = new List<CityDto>();

            //for (int Counter = 0; Counter < Cities.Count(); Counter++)
            //{
            //    CityDto CityDto_Object = new CityDto();

            //    CityDto_Object.Id = Cities[Counter].Id;
            //    CityDto_Object.Name = Cities[Counter].Name;
            //    CityDto_Object.Description = Cities[Counter].Description;
            //    CityDto_Object.PointsOfInterest = new List<PointOfInterestDto>();

            //    for (int PointOfInterestsCounter = 0;
            //        PointOfInterestsCounter < Cities[Counter].PointsOfInterest.Count();
            //        PointOfInterestsCounter++)
            //    {
            //        PointOfInterestDto PointOfInterestDto_Object = new PointOfInterestDto();
            //        PointOfInterestDto_Object.Id = Cities[Counter].PointsOfInterest.ElementAt(PointOfInterestsCounter).Id;
            //        PointOfInterestDto_Object.CityID = Cities[Counter].PointsOfInterest.ElementAt(PointOfInterestsCounter).CityId;
            //        PointOfInterestDto_Object.Name = Cities[Counter].PointsOfInterest.ElementAt(PointOfInterestsCounter).Name;
            //        PointOfInterestDto_Object.Description = Cities[Counter].PointsOfInterest.ElementAt(PointOfInterestsCounter).Description;

            //        CityDto_Object.PointsOfInterest.Add(PointOfInterestDto_Object);
            //    }

            //    CityDto_Object.CityLanguages = new List<LanguageDto>();
            //    for (int CityLanguageCounter = 0;
            //        CityLanguageCounter < Cities[Counter].CityLanguages.Count();
            //        CityLanguageCounter++)
            //    {
            //        LanguageDto LanguageDto_Object = new LanguageDto();
            //        LanguageDto_Object.Id = Cities[Counter].CityLanguages.ElementAt(CityLanguageCounter).LanguageId;
            //        LanguageDto_Object.LanguageName = Cities[Counter].CityLanguages.ElementAt(CityLanguageCounter).Language.LanguageName;

            //        CityDto_Object.CityLanguages.Add(LanguageDto_Object);
            //    }
            //    CityDtos.Add(CityDto_Object);
            //}

            //CityDto CityDto_Object_Final = new CityDto();
            //CityDto_Object_Final.Id = 0;
            //CityDto_Object_Final.Name = "Egen Konvertering !!!";
            //CityDto_Object_Final.Description = "Det sidste objekt her er lavet for at illustrere det arbejde, som AutoMapper gør for os !!!";

            //CityDtos.Add(CityDto_Object_Final);

            //return (CityDtos);

            return (null);
        }
    }
}
