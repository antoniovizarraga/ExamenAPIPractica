using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class miApiController : ControllerBase
    {
        // GET: api/<miApiController>
        [HttpGet]
        public List<Persona> Get()
        {
            return ListadoPersonas.ListarPersonas();
        }

        // GET api/<miApiController>/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {
            return ListadoPersonas.BuscarPersonaPorId(id);
        }

        // POST api/<miApiController>
        [HttpPost]
        public void Post([FromBody] Persona persona)
        {
            ListadoPersonas.CrearPersona(persona);
        }

        // PUT api/<miApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Persona per)
        {
            ListadoPersonas.ActualizarPersona(id, per);
        }

        // DELETE api/<miApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ListadoPersonas.EliminarPersona(id);
        }
    }
}
