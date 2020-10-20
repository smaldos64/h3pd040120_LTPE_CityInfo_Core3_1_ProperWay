using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Interfaces;
using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Profiles;
using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data_Async.Entities;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi_Async.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        public LanguageController(IRepositoryWrapper repositoryWrapper,
                              IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            this._mapper = mapper;
        }

        // GET: api/Language
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetLanguages(bool includeRelations = false)
        {
            if (false == includeRelations)
            {
                _repositoryWrapper.LanguageRepositoryWrapper.DisableLazyLoading();
            }
            else  // true == includeRelations 
            {
                _repositoryWrapper.LanguageRepositoryWrapper.EnableLazyLoading();
            }

            var languageEntities = await _repositoryWrapper.LanguageRepositoryWrapper.FindAll();

            var languageDtos = _mapper.Map<IEnumerable<LanguageDto>>(languageEntities);

            return Ok(languageDtos);
        }

        [HttpGet("{LanguageId}", Name = "GetLanguages")]
        public async Task <ActionResult<LanguageDto>> GetLanguage(int languageId, bool includeRelations = false)
        {
            if (false == includeRelations)
            {
                _repositoryWrapper.LanguageRepositoryWrapper.DisableLazyLoading();
            }
            else  // true == includeRelations 
            {
                _repositoryWrapper.LanguageRepositoryWrapper.EnableLazyLoading();
            }

            var LanguageFromRepo = await _repositoryWrapper.LanguageRepositoryWrapper.FindOne(languageId);
            return Ok(_mapper.Map<LanguageDto>(LanguageFromRepo));
        }


        [HttpPost]
        public async Task<IActionResult> AddLanguages([FromBody]Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repositoryWrapper.LanguageRepositoryWrapper.Create(language);

            return Ok(language);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage(int languageId, [FromBody] LanguageOfUpdate language)
        {
            var LanguageFromRepo = await _repositoryWrapper.LanguageRepositoryWrapper.FindOne(languageId);
            if (LanguageFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(language, LanguageFromRepo);

            await _repositoryWrapper.LanguageRepositoryWrapper.Update(LanguageFromRepo);

            return NoContent();
        }

        [HttpDelete("{LanguageId}")]
        public async Task<IActionResult> RemoveLanguage(int languageId)
        {
            var LanguageFromRepo = await _repositoryWrapper.LanguageRepositoryWrapper.FindOne(languageId);
            if (LanguageFromRepo == null)
            {
                return NotFound();
            }

            await _repositoryWrapper.LanguageRepositoryWrapper.Delete(LanguageFromRepo);
            
            return NoContent();
        }

        [HttpGet("{LanguageId}/cities")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCitiesFromLanguages(int languageId)
        {
            var LanguageFromRepo = await _repositoryWrapper.LanguageRepositoryWrapper.FindOne(languageId);
            if (LanguageFromRepo == null)
            {
                return NotFound();
            }

            _repositoryWrapper.LanguageRepositoryWrapper.EnableLazyLoading();

            var CityLanguages = await _repositoryWrapper.CityLanguageRepositoryWrapper.GetAllCitiesFromLanguageID(languageId);

            var CitiesFromRepo = await _repositoryWrapper.CityInfoRepositoryWrapper.GetCitiesFromLanguageID(languageId);
                                  
            return Ok(_mapper.Map<IEnumerable<CityDto>>(CitiesFromRepo));
        }
    }
}
