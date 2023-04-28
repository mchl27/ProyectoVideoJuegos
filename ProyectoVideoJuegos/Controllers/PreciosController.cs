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
    public class PreciosController : Controller
    {
        private readonly ProyectoVideoJuegosDBContext _context;

        public PreciosController(ProyectoVideoJuegosDBContext context)
        {
            _context = context;
        }

        // GET: Precios
        public async Task<IActionResult> Index()
        {
            var proyectoVideoJuegosDBContext = _context.Precios.Include(p => p.TituloNavigation);
            return View(await proyectoVideoJuegosDBContext.ToListAsync());
        }

        // GET: Precios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precio = await _context.Precios
                .Include(p => p.TituloNavigation)
                .FirstOrDefaultAsync(m => m.IdPrecio == id);
            if (precio == null)
            {
                return NotFound();
            }

            return View(precio);
        }

        // GET: Precios/Create
        public IActionResult Create()
        {
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo");
            return View();
        }

        // POST: Precios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrecio,Titulo,FechaInicio,FechaFin,Precio1")] Precio precio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo", precio.Titulo);
            return View(precio);
        }

        // GET: Precios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precio = await _context.Precios.FindAsync(id);
            if (precio == null)
            {
                return NotFound();
            }
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo", precio.Titulo);
            return View(precio);
        }

        // POST: Precios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrecio,Titulo,FechaInicio,FechaFin,Precio1")] Precio precio)
        {
            if (id != precio.IdPrecio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecioExists(precio.IdPrecio))
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
            ViewData["Titulo"] = new SelectList(_context.Juegos, "Titulo", "Titulo", precio.Titulo);
            return View(precio);
        }

        // GET: Precios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precio = await _context.Precios
                .Include(p => p.TituloNavigation)
                .FirstOrDefaultAsync(m => m.IdPrecio == id);
            if (precio == null)
            {
                return NotFound();
            }

            return View(precio);
        }

        // POST: Precios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var precio = await _context.Precios.FindAsync(id);
            _context.Precios.Remove(precio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecioExists(int id)
        {
            return _context.Precios.Any(e => e.IdPrecio == id);
        }
    }
}
