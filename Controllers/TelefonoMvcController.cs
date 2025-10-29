using Microsoft.AspNetCore.Mvc;
using personapi.Interfaces;
using personapi.Models.Entities;

namespace personapi.Controllers
{
    public class TelefonoMvcController : Controller
    {
        private readonly ITelefonoRepository _repo;

        public TelefonoMvcController(ITelefonoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var telefonos = _repo.GetAll();
            return View(telefonos);
        }

        [HttpGet]
        public IActionResult Buscar(string num)
        {
            var telefono = _repo.GetById(num);
            if (telefono == null)
            {
                ViewBag.Mensaje = "No se encontró el teléfono con ese número.";
                return View("Index", _repo.GetAll());
            }

            return View("Index", new List<Telefono> { telefono });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            if (!ModelState.IsValid)
                return View(telefono);

            _repo.Add(telefono);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string num)
        {
            var telefono = _repo.GetById(num);
            if (telefono == null)
                return NotFound();

            return View(telefono);
        }

        [HttpPost]
        public IActionResult Edit(Telefono telefono)
        {
            _repo.Update(telefono);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string num)
        {
            _repo.Delete(num);
            return RedirectToAction("Index");
        }
    }
}
