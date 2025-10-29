using Microsoft.AspNetCore.Mvc;
using personapi.Interfaces;
using personapi.Models.Entities;

namespace personapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _repo;

        public TelefonoController(ITelefonoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{num}")]
        public IActionResult GetById(string num)
        {
            var t = _repo.GetById(num);
            return t == null ? NotFound() : Ok(t);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Telefono telefono)
        {
            _repo.Add(telefono);
            return Created("", telefono);
        }

        [HttpPut("{num}")]
        public IActionResult Update(string num, [FromBody] Telefono telefono)
        {
            if (num != telefono.Num)
                return BadRequest();

            _repo.Update(telefono);
            return NoContent();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            var total = _repo.Count();
            return Ok(new { total });
        }


        [HttpDelete("{num}")]
        public IActionResult Delete(string num)
        {
            _repo.Delete(num);
            return NoContent();
        }
    }
}
