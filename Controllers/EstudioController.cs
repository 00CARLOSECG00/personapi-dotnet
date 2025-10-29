using Microsoft.AspNetCore.Mvc;
using personapi.Interfaces;
using personapi.Models.Entities;

namespace personapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudioController : ControllerBase
    {
        private readonly IEstudioRepository _repo;

        public EstudioController(IEstudioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{idProf}/{ccPer}")]
        public IActionResult GetById(int idProf, int ccPer)
        {
            var e = _repo.GetById(idProf, ccPer);
            return e == null ? NotFound() : Ok(e);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Estudio estudio)
        {
            _repo.Add(estudio);
            return Created("", estudio);
        }

        [HttpPut("{idProf}/{ccPer}")]
        public IActionResult Update(int idProf, int ccPer, [FromBody] Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
                return BadRequest();

            _repo.Update(estudio);
            return NoContent();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            var total = _repo.Count();
            return Ok(new { total });
        }


        [HttpDelete("{idProf}/{ccPer}")]
        public IActionResult Delete(int idProf, int ccPer)
        {
            _repo.Delete(idProf, ccPer);
            return NoContent();
        }
    }
}
