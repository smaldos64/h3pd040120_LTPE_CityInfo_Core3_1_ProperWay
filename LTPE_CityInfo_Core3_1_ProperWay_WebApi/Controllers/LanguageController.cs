using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Profiles;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Models;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Entities;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi.Controllers
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
        public ActionResult<IEnumerable<LanguageDto>> GetLanguages(bool includeRelations = false)
        {
            if (false == includeRelations)
            {
                _repositoryWrapper.LanguageRepositoryWrapper.DisableLazyLoading();
            }
            else  // true == includeRelations 
            {
                _repositoryWrapper.LanguageRepositoryWrapper.EnableLazyLoading();
            }

            var languageEntities = _repositoryWrapper.LanguageRepositoryWrapper.FindAll();

            var languageDtos = _mapper.Map<IEnumerable<LanguageDto>>(languageEntities);

            return Ok(languageDtos);
        }

        [HttpGet("{LanguageId}", Name = "GetLanguages")]
        public ActionResult<LanguageDto> GetLanguage(int languageId, bool includeRelations = false)
        {
            if (false == includeRelations)
            {
                _repositoryWrapper.LanguageRepositoryWrapper.DisableLazyLoading();
            }
            else  // true == includeRelations 
            {
                _repositoryWrapper.LanguageRepositoryWrapper.EnableLazyLoading();
            }

            var LanguageFromRepo = _repositoryWrapper.LanguageRepositoryWrapper.FindOne(languageId);
            return Ok(_mapper.Map<LanguageDto>(LanguageFromRepo));
        }


        [HttpPost]
        public IActionResult AddLanguages([FromBody]Language language)
        {
            /*var finalLanguage = _mapper.Map<Data.Entities.Language>(language);

            _cityInfoRepository.AddLanguage(finalLanguage);
            _cityInfoRepository.Save();

            var LaunguageToReturn = _mapper.Map<Data.Models.LanguageDto>(finalLanguage);
            return CreatedAtRoute("GetLanguages",
                new
                {
                    languageId = LaunguageToReturn.Id
                }, LaunguageToReturn);*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repositoryWrapper.LanguageRepositoryWrapper.Create(language);

            return Ok(language);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLanguage(int languageId, [FromBody] LanguageOfUpdate language)
        {
            var LanguageFromRepo = _repositoryWrapper.LanguageRepositoryWrapper.FindOne(languageId);
            if (LanguageFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(language, LanguageFromRepo);

            _repositoryWrapper.LanguageRepositoryWrapper.Update(LanguageFromRepo);

            return NoContent();
        }

        [HttpDelete("{LanguageId}")]
        public IActionResult RemoveLanguage(int languageId)
        {
            var LanguageFromRepo = _repositoryWrapper.LanguageRepositoryWrapper.FindOne(languageId);
            if (LanguageFromRepo == null)
            {
                return NotFound();
            }

            _repositoryWrapper.LanguageRepositoryWrapper.Delete(LanguageFromRepo);
            
            return NoContent();
        }

        [HttpGet("{LanguageId}/cities")]
        public ActionResult<IEnumerable<CityDto>> GetCitiesFromLanguages(int languageId)
        {
            var LanguageFromRepo = _repositoryWrapper.LanguageRepositoryWrapper.FindOne(languageId);
            if (LanguageFromRepo == null)
            {
                return NotFound();
            }

            _repositoryWrapper.LanguageRepositoryWrapper.EnableLazyLoading();

            var CityLanguages = _repositoryWrapper.CityLanguageRepositoryWrapper.GetAllCitiesFromLanguageID(languageId);

            var CitiesFromRepo = _repositoryWrapper.CityInfoRepositoryWrapper.GetCitiesFromLanguageID(languageId);
                                  
            return Ok(_mapper.Map<IEnumerable<CityDto>>(CitiesFromRepo));
        }
    }
}
