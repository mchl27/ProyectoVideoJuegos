using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVideoJuegos.Models;

namespace ProyectoVideoJuegos.Controllers
{
    public class AlquileresController : Controller
    {
        private readonly ProyectoVideoJuegosDBContext _context;

        public AlquileresController(ProyectoVideoJuegosDBContext context)
        {
            _context = context;
        }

        // GET: Alquileres
        public async Task<IActionResult> Index()
        {
            var proyectoVideoJuegosDBContext = _context.Alquileres.Include(a => a.NombreNavigation).Include(a => a.TituloNavigation);
            return View(await proyectoVideoJuegosDBContext.ToListAsync());
        }

        public async Task<IActionResult> Alquilar()
        {
            var proyectoVideoJuegosDBContext = _context.Alquileres.Include(a => a.NombreNavigation).Include(a => a.TituloNavigation);
            return View(await proyectoVideoJuegosDBContext.ToListAsync());
        }


        // GET: Alquileres/Create
        public IActionResult Alquilarcreacion()
        {
            ViewData["Nombre"] = new SelectList(_context.Clientes, "Nombre", "Nombre");
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo");
            return View();
        }

        // POST: Alquileres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alquilarcreacion([Bind("IdAlquiler,Nombre,Titulo,FechaAlquiler,FechaVencimiento,Precio")] Alquilere alquilere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquilere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Alquilar));
            }
            ViewData["Nombre"] = new SelectList(_context.Clientes, "Nombre", "Nombre", alquilere.Nombre);
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo", alquilere.Titulo);
            return View(alquilere);
        }


        // GET: Alquileres/Details/5
        public async Task<IActionResult> Alquilardetalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilere = await _context.Alquileres
                .Include(a => a.NombreNavigation)
                .Include(a => a.TituloNavigation)
                .FirstOrDefaultAsync(m => m.IdAlquiler == id);
            if (alquilere == null)
            {
                return NotFound();
            }

            return View(alquilere);
        }


        //  CONSULTAS //

        public async Task<IActionResult> ClientemasfrecuenteAsync()
        {
            var clienteMasFrecuente = await _context.Alquileres
            .GroupBy(a => a.NombreNavigation.Nombre)
            .Select(g => new { ClienteId = g.Key, Cantidad = g.Count() })
            .OrderByDescending(x => x.Cantidad)
            .FirstOrDefaultAsync();

            if (clienteMasFrecuente != null)
            {
                var cliente = clienteMasFrecuente.ClienteId;
                ViewData["clienteMasFrecuente"] = cliente;
            }
            else
            {
                ViewData["clienteMasFrecuente"] = "No se encontraron datos";
            }

            return View();
        }


        public async Task<IActionResult> Titulomasrentado()
        {
            var tituloMasRentado = await _context.Alquileres
                .GroupBy(a => a.Titulo)
                .Select(g => new { Titulo = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .FirstOrDefaultAsync();

            if (tituloMasRentado != null)
            {
                var titulo = tituloMasRentado.Titulo;
                ViewData["tituloMasRentado"] = titulo;
            }
            else
            {
                ViewData["tituloMasRentado"] = "No se encontraron datos";
            }

            return View();
        }

        public IActionResult Ventasdia()
        {
            DateTime today = DateTime.Now.Date;
            var alquileresDelDia = _context.Alquileres.Where(a => a.FechaAlquiler.Date == today);

            decimal totalVentas = 0;
            foreach (var alquiler in alquileresDelDia)
            {
                totalVentas += alquiler.Precio;
            }

            ViewBag.TotalVentas = totalVentas;
            return View();
        }

        // GET: Alquileres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilere = await _context.Alquileres
                .Include(a => a.NombreNavigation)
                .Include(a => a.TituloNavigation)
                .FirstOrDefaultAsync(m => m.IdAlquiler == id);
            if (alquilere == null)
            {
                return NotFound();
            }

            return View(alquilere);
        }


        // GET: Alquileres/Create
        public IActionResult Create()
        {
            ViewData["Nombre"] = new SelectList(_context.Clientes, "Nombre", "Nombre");
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo");
            return View();
        }

        // POST: Alquileres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlquiler,Nombre,Titulo,FechaAlquiler,FechaVencimiento,Precio")] Alquilere alquilere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquilere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Alquilar));
            }
            ViewData["Nombre"] = new SelectList(_context.Clientes, "Nombre", "Nombre", alquilere.Nombre);
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo", alquilere.Titulo);
            return View(alquilere);
        }

        // GET: Alquileres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilere = await _context.Alquileres.FindAsync(id);
            if (alquilere == null)
            {
                return NotFound();
            }
            ViewData["Nombre"] = new SelectList(_context.Clientes, "Nombre", "Nombre", alquilere.Nombre);
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo", alquilere.Titulo);
            return View(alquilere);
        }

        // POST: Alquileres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlquiler,Nombre,Titulo,FechaAlquiler,FechaVencimiento,Precio")] Alquilere alquilere)
        {
            if (id != alquilere.IdAlquiler)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquilere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilereExists(alquilere.IdAlquiler))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nombre"] = new SelectList(_context.Clientes, "Nombre", "Nombre", alquilere.Nombre);
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo", alquilere.Titulo);
            return View(alquilere);
        }

        // GET: Alquileres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilere = await _context.Alquileres
                .Include(a => a.NombreNavigation)
                .Include(a => a.TituloNavigation)
                .FirstOrDefaultAsync(m => m.IdAlquiler == id);
            if (alquilere == null)
            {
                return NotFound();
            }

            return View(alquilere);
        }

        // POST: Alquileres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alquilere = await _context.Alquileres.FindAsync(id);
            _context.Alquileres.Remove(alquilere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilereExists(int id)
        {
            return _context.Alquileres.Any(e => e.IdAlquiler == id);
        }
    }
}
