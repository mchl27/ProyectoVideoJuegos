using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoVideoJuegos.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVideoJuegos.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            return View();
        }



        private readonly ProyectoVideoJuegosDBContext _context;

        public PrincipalController(ProyectoVideoJuegosDBContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Login(string nombreUsuario, string contrasena)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Username == nombreUsuario && u.Contraseña == contrasena);

            if (usuario != null)
            {
                // Iniciar sesión exitosa.
                return RedirectToAction("Index", "Principal");
            }
            else
            {
                // Nombre de usuario o contraseña incorrectos.
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                return View();
            }
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Apellido,Username,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(usuario);
        }


        
    }
}
