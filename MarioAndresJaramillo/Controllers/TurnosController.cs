using MarioAndresJaramillo.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarioAndresJaramillo.Controllers
{
    public class TurnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //por medio de entity solo necesitamos instanciar el applicationDbContext para manipular los modelos
        //traemos en el  index en una lista de los turnos
        public IActionResult Index()
        {
            var turnos = _context.Turnos.ToList();
            return View(turnos);
        }

        //creamos el metodo para crear por medio del POST
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Turno turno)
        {
            if (ModelState.IsValid)
            {
                _context.Turnos.Add(turno);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turno);
        }

        //Creamos el metodo editar por medio del Id
        public IActionResult Editar(int id)
        {
            var turno = _context.Turnos.Find(id);
            if (turno == null)
            {
                return NotFound();
            }
            return View(turno);
        }

        [HttpPost]
        public IActionResult Editar(int id, Turno turno)
        {
            if (id != turno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(turno);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turno);
        }
        //creamos el metodo elimar
        public IActionResult Eliminar(int id)
        {
            var turno = _context.Turnos.Find(id);
            if (turno == null)
            {
                return NotFound();
            }
            return View(turno);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult ConfirmarEliminar(int id)
        {
            var turno = _context.Turnos.Find(id);
            if (turno == null)
            {
                return NotFound();
            }

            _context.Turnos.Remove(turno);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
