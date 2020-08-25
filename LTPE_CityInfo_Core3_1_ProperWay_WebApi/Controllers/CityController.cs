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
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private IMapper _mapper;

        public CityController(IRepositoryWrapper repoWrapper,
                              IMapper mapper)
        {
            this._repoWrapper = repoWrapper;
            this._mapper = mapper;
        }

        // GET: api/City
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/City/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public IActionResult GetCities(bool includeRelations = false)
        {
#if (Use_Lazy_Loading_On_City_Controller)
            if (false == includeRelations)
            {
                _repoWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();
                var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.FindAll();
#if (Show_Empty_Related_Date_Fields)
                IEnumerable<CityDto> CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);
#else
                IEnumerable<CityWithoutPointsOfInterestDto> CityDtos = _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);
#endif
                return Ok(CityDtos);
            }
            else
            {
                _repoWrapper.CityInfoRepositoryWrapper.EnableLazyLoading();
                var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.FindAll();
                IEnumerable<CityDto> CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);
#if (Show_Loaded_Trash_Data)
                return Ok(cityEntities);
#else
                return Ok(CityDtos);
#endif
            }
#else
            _repoWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();
            if (false == includeRelations)
            {
                var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.GetAllCities(includeRelations);
                IEnumerable<CityWithoutPointsOfInterestDto> CityDtos = _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);
                return Ok(CityDtos);
            }
            else
            {
                //var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.FindByCondition(c => c.Id == c.Id);
                var cityEntities = _repoWrapper.CityInfoRepositoryWrapper.GetAllCities(includeRelations);
                IEnumerable<CityDto> CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);
#if (Show_Loaded_Trash_Data)
                return Ok(cityEntities);
#else
                return Ok(CityDtos);
#endif
            }
#endif
        }

        // POST: api/City
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
