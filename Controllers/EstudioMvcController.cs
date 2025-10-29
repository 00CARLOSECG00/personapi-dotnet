using Microsoft.AspNetCore.Mvc;
using personapi.Interfaces;
using personapi.Models.Entities;

namespace personapi.Controllers
{
    public class EstudioMvcController : Controller
    {
        private readonly IEstudioRepository _repo;

        public EstudioMvcController(IEstudioRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var estudios = _repo.GetAll();
            return View(estudios);
        }


        [HttpGet]
        public IActionResult Buscar(int id_prof, int cc_per)
        {
            var estudio = _repo.GetById(id_prof, cc_per);
            if (estudio == null)
            {
                ViewBag.Mensaje = "No se encontró el estudio.";
                return View("Index", _repo.GetAll());
            }

            return View("Index", new List<Estudio> { estudio });
        }




        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            if (!ModelState.IsValid)
                return View(estudio);

            _repo.Add(estudio);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id_prof, int cc_per)
        {
            var estudio = _repo.GetById(id_prof, cc_per);
            if (estudio == null)
                return NotFound();

            return View(estudio);
        }

        [HttpPost]
        public IActionResult Edit(Estudio estudio)
        {
            _repo.Update(estudio);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id_prof, int cc_per)
        {
            _repo.Delete(id_prof, cc_per);
            return RedirectToAction("Index");
        }
    }
}
