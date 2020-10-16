using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Entities;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityAsyncController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        public CityAsyncController(IRepositoryWrapper repositoryWrapper,
                                   IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            this._mapper = mapper;
        }

        // GET: api/CityAsync
        [HttpGet]
        public async Task <IActionResult> GetCities(bool includeRelations = false)
        {
            if (false == includeRelations)
            {
                _repositoryWrapper.CityInfoRepositoryWrapper.DisableLazyLoading();
            }
            else  // true == includeRelations 
            {
                _repositoryWrapper.CityInfoRepositoryWrapper.EnableLazyLoading();
            }

            var t1 = new Task(() => { var cityEntities = _repositoryWrapper.CityInfoRepositoryWrapper.FindAll();
                var CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);
                return Ok(CityDtos);
            });

            // Koden der er udkommenteret herunder er med for at vise, at man kan nå alle
            // wrappere fra alle controllers. 
            //var LanguageEntities = _repositoryWrapper.LanguageRepositoryWrapper.FindAll();

            //var CityDtos = _mapper.Map<IEnumerable<CityDto>>(cityEntities);

            //return Ok(CityDtos);
        }

        // GET: api/CityAsync/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CityAsync
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CityAsync/5
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
