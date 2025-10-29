using Microsoft.AspNetCore.Mvc;
using personapi.Interfaces;
using personapi.Models.Entities;
using personapi.Repositories;

namespace personapi.Controllers
{
    public class PersonaMvcController : Controller
    {
        private readonly IPersonaRepository _repo;

        public PersonaMvcController(IPersonaRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var personas = _repo.GetAll();
            return View(personas);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            if (!ModelState.IsValid)
                return View(persona);

            _repo.Add(persona);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int cc)
        {
            var persona = _repo.GetById(cc);
            if (persona == null)
                return NotFound();

            return View(persona);
        }
        [HttpGet]
        public IActionResult Buscar(int id)
        {
            var persona = _repo.GetById(id);
            if (persona == null)
            {
                ViewBag.Mensaje = "No se encontró ninguna persona con esa cédula.";
                return View("Index", _repo.GetAll());
            }

            return View("Index", new List<Persona> { persona });
        }


        [HttpPost]
        public IActionResult Edit(Persona persona)
        {
            _repo.Update(persona);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int cc)
        {
            _repo.Delete(cc);
            return RedirectToAction("Index");
        }
    }
}
