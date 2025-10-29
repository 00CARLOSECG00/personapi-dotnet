using Microsoft.AspNetCore.Mvc;
using personapi.Interfaces;
using personapi.Models.Entities;

namespace personapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionController : ControllerBase
    {
        private readonly IProfesionRepository _repo;

        public ProfesionController(IProfesionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var p = _repo.GetById(id);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Profesion profesion)
        {
            _repo.Add(profesion);
            return Created("", profesion);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Profesion profesion)
        {
            if (id != profesion.Id)
                return BadRequest();

            _repo.Update(profesion);
            return NoContent();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            var total = _repo.Count();
            return Ok(new { total });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return NoContent();
        }
    }
}
