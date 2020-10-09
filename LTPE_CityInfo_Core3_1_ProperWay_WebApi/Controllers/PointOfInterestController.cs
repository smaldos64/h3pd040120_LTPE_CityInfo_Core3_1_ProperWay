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
    public class PointOfInterestController : ControllerBase
    {
        // GET: api/PointOfInterest
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PointOfInterest/5
        [HttpGet("{id}", Name = "GetPointOfInterest")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PointOfInterest
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PointOfInterest/5
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
