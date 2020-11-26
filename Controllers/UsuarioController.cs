using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoC.Data;
using PoC.Models;

namespace PoC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ApplicationDbContext db, ILogger<UsuarioController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Usuario> Usuarios = _db.Usuario;
            return View(Usuarios);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _db.Usuario.Add(usuario);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var usuario = _db.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _db.Usuario.Update(usuario);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var usuario = _db.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirPost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var usuario = _db.Usuario.Find(id);
            if (usuario == null)
                return NotFound();

            _db.Usuario.Remove(usuario);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
