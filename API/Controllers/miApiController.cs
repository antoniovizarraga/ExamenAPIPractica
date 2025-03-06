using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class miApiController : ControllerBase
    {
        // GET: api/<miApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<miApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<miApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<miApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<miApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
