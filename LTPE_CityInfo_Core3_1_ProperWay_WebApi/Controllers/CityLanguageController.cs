using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityLanguageController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        public CityLanguageController(IRepositoryWrapper repositoryWrapper,
                                      IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            this._mapper = mapper;
        }

        // GET: api/CityLanguage
        [HttpGet]
        public IActionResult GetCityLanguages(bool includeRelations = false)
        {
            if (false == includeRelations)
            {
                _repositoryWrapper.CityLanguageRepositoryWrapper.DisableLazyLoading();
            }
            else  // true == includeRelations 
            {
                _repositoryWrapper.CityLanguageRepositoryWrapper.EnableLazyLoading();
            }

            var cityLanguageEntitiesLazyLoading = _repositoryWrapper.CityLanguageRepositoryWrapper.FindAll();
            var cityLanguageEntitiesEagerLoading = _repositoryWrapper.CityLanguageRepositoryWrapper.GetAllCitiesLanguages();

            var CityLanguageDtosLazyLoading = _mapper.Map<IEnumerable<CityLanguageDto>>(cityLanguageEntitiesLazyLoading);
            var CityLanguageDtosEagerLoading = _mapper.Map<IEnumerable<CityLanguageDto>>(cityLanguageEntitiesEagerLoading);

            return Ok(CityLanguageDtosLazyLoading);
        }

        // GET: api/CityLanguage/5
        [HttpGet("{id}", Name = "GetCityLanguage")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CityLanguage
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CityLanguage/5
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
