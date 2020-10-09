using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTPE_CityInfo_Core3_1_ProperWay_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityLanguageController : ControllerBase
    {
        // GET: api/CityLanguage
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
