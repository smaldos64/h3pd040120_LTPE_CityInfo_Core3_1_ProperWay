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
using LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi.Controllers
{
    public class CityControllerParameters
    {
        public bool _use_Lazy_Loading_On_City_Controller = true;
        public bool _show_Loaded_Trash_Data = false;
        public bool _show_Empty_Related_Date_Fields = false;
        public bool _use_AutoMapper = true;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        // De 4 parametre bestemmer hvordan output data fra controlleren her
        // præsenteres og behandles for klienten. 
        // Parameterne er medtaget først og fremmest af uddennelsesmæssige
        // formål, således at brugerne af controlleren her, kan se
        // hvordan man kan returnere (relationelle) data på forskellige måder fra en 
        // controller tilbage til en klient.
        //private bool _use_Lazy_Loading_On_City_Controller = true;
        //private bool _show_Loaded_Trash_Data = false;
        //private bool _show_Empty_Related_Date_Fields = false;
        //private bool _use_AutoMapper = true;

        private static CityControllerParameters _cityControllerParameters_Object = new CityControllerParameters();

        private IRepositoryWrapper _repoWrapper;
        private IMapper _mapper;

        public CityController(IRepositoryWrapper repoWrapper,
                              IMapper mapper)
        {
            this._repoWrapper = repoWrapper;
            this._mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult GetCities(bool includeRelations = false)
        {
            if (_cityControllerParameters_Object._use_Lazy_Loading_On_City_Controller)
            {
                if (false == includeRelations)
                {
                    _repoWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

                    var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.FindAll();

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
                    _repoWrapper.CityInfoRepositoryWrapper.EnableLazyLoading();

                    var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.FindAll();
                    IEnumerable<CityDto> CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);

                    if (_cityControllerParameters_Object._show_Loaded_Trash_Data)
                    {
                        return Ok(cityEntities);
                    }
                    else
                    {
                        return Ok(CityDtos);
                    }
                }
            }
            else  // !_use_Lazy_Loading_On_City_Controller
            {
                _repoWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

                if (false == includeRelations)
                {
                    var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.GetAllCities(includeRelations);

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
                    //var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.FindByCondition(c => c.Id == c.Id);
                    var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.GetAllCities(includeRelations);
                    IEnumerable<CityDto> CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);

                    if (_cityControllerParameters_Object._show_Loaded_Trash_Data)
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

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id, bool includeRelations = false)
        {
            if (_cityControllerParameters_Object._use_Lazy_Loading_On_City_Controller)
            {
                if (false == includeRelations)
                {
                    _repoWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

                    var cityEntity = _repoWrapper.CityInfoRepositoryWrapper.FindOne(id);

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
                    _repoWrapper.CityInfoRepositoryWrapper.EnableLazyLoading();

                    var cityEntity = _repoWrapper.CityInfoRepositoryWrapper.FindOne(id);

                    if (null == cityEntity)
                    {
                        return NotFound();
                    }
                    else
                    {
                        CityDto CityDto_Object = _mapper.Map<CityDto>(cityEntity);
                        if (_cityControllerParameters_Object._show_Loaded_Trash_Data)
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
                _repoWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();

                if (false == includeRelations)
                {
                    var cityEntity = _repoWrapper.CityInfoRepositoryWrapper.GetCity(id, includeRelations);

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
                    var cityEntity = _repoWrapper.CityInfoRepositoryWrapper.GetCity(id, includeRelations);

                    if (null == cityEntity)
                    {
                        return NotFound();
                    }
                    else
                    {
                        CityDto CityDto_Object = _mapper.Map<CityDto>(cityEntity);

                        if (_cityControllerParameters_Object._show_Loaded_Trash_Data)
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
        public void Post([FromBody] string value)
        {
        }

        // POST: api/Controller Parameters
        [HttpPost]
        [Route("[action]")]
        public IActionResult PostControllerSettingParameters(bool Use_Lazy_Loading_On_City_Controller = true,
                                                             bool Show_Loaded_Trash_Data = false,
                                                             bool Show_Empty_Related_Date_Fields = false,
                                                             bool Use_AutoMapper = true)
        {
            _cityControllerParameters_Object._use_Lazy_Loading_On_City_Controller = Use_Lazy_Loading_On_City_Controller;
            _cityControllerParameters_Object._show_Loaded_Trash_Data = Show_Loaded_Trash_Data;
            _cityControllerParameters_Object._show_Empty_Related_Date_Fields = Show_Empty_Related_Date_Fields;
            _cityControllerParameters_Object._use_AutoMapper = Use_AutoMapper;

            return Ok(_cityControllerParameters_Object);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
