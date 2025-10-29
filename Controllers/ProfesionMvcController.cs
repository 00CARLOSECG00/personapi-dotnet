using Microsoft.AspNetCore.Mvc;
using personapi.Interfaces;
using personapi.Models.Entities;

namespace personapi.Controllers
{
    public class ProfesionMvcController : Controller
    {
        private readonly IProfesionRepository _repo;

        public ProfesionMvcController(IProfesionRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var profesiones = _repo.GetAll();
            return View(profesiones);
        }

        [HttpGet]
        public IActionResult Buscar(int id)
        {
            var profesion = _repo.GetById(id);
            if (profesion == null)
            {
                ViewBag.Mensaje = "No se encontró ninguna profesión con ese ID.";
                return View("Index", _repo.GetAll());
            }

            return View("Index", new List<Profesion> { profesion });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Profesion profesion)
        {
            if (!ModelState.IsValid)
                return View(profesion);

            _repo.Add(profesion);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var profesion = _repo.GetById(id);
            if (profesion == null)
                return NotFound();

            return View(profesion);
        }

        [HttpPost]
        public IActionResult Edit(Profesion profesion)
        {
            _repo.Update(profesion);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
