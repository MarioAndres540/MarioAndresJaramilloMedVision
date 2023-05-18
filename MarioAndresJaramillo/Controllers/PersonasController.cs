using MarioAndresJaramillo.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarioAndresJaramillo.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        //traemos la informacion de las peronas por medio de una lista
        public IActionResult Index()
        {
            var personas = _context.Personas.ToList();
            return View(personas);
        }

        public IActionResult Crear()
        {
            return View();
        }

        //creamos  el metodo para crear cada persona
        [HttpPost]
        public IActionResult Crear(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        //creamos el metodo para editar por medio dela cedula
        public IActionResult Editar(int Cedula)
        {
            var persona = _context.Personas.Find(Cedula);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        [HttpPost]
        public IActionResult Editar(int Cedula, Persona persona)
        {
            if (Cedula != persona.Cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(persona);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        //creamos el metodo Eliminar

        public IActionResult Eliminar(int Cedula)
        {
            var persona = _context.Personas.Find(Cedula);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult ConfirmarEliminar(int Cedula)
        {
            var persona = _context.Personas.Find(Cedula);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
