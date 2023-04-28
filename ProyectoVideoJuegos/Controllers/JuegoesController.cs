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
    public class JuegoesController : Controller
    {
        private readonly ProyectoVideoJuegosDBContext _context;

        public JuegoesController(ProyectoVideoJuegosDBContext context)
        {
            _context = context;
        }

        // GET: Juegoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Juegos.ToListAsync());
        }

        public async Task<IActionResult> Juegos()
        {
            return View(await _context.Juegos.ToListAsync());
        }


        public async Task<IActionResult> Juegosprincipal()
        {
            return View(await _context.Juegos.ToListAsync());
        }

        /////////////////      CONSULTAS A LAS DIFERENTES COLUMNAS DE LA TABLA USUARIO     ////////////////
        // 1. CONSULTA AL DIRECTOR
        // GET: Juegoes
        public async Task<IActionResult> Juegosconsulta(string buscar)
        {
            var director = from Juego in _context.Juegos select Juego;

            if (!String.IsNullOrEmpty(buscar))
            {
                director = director.Where(s => s.Director!.Contains(buscar));
            }
            return View(await director.ToListAsync());
        }
        // 2. CONSULTA A LOS PROTAGONISTAS
        public async Task<IActionResult> Juegosconsulta1(string buscar)
        {
            var protagonista = from Juego in _context.Juegos select Juego;

            if (!String.IsNullOrEmpty(buscar))
            {
                protagonista = protagonista.Where(s => s.Protagonistas!.Contains(buscar));
            }
            return View(await protagonista.ToListAsync());
        }

        // 3. CONSULTA AL PRODUCTOR
        public async Task<IActionResult> Juegosconsulta2(string buscar)
        {
            var productor = from Juego in _context.Juegos select Juego;

            if (!String.IsNullOrEmpty(buscar))
            {
                productor = productor.Where(s => s.Productor!.Contains(buscar));
            }
            return View(await productor.ToListAsync());
        }


        // GET: Juegoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.Titulo == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // GET: Juegoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juegoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJuego,Titulo,Año,Protagonistas,Director,Productor,Plataforma,PrecioAlquiler")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juego);
        }

        // GET: Juegoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos.FindAsync(id);
            if (juego == null)
            {
                return NotFound();
            }
            return View(juego);
        }

        // POST: Juegoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdJuego,Titulo,Año,Protagonistas,Director,Productor,Plataforma,PrecioAlquiler")] Juego juego)
        {
            if (id != juego.Titulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuegoExists(juego.Titulo))
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
            return View(juego);
        }

        // GET: Juegoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.Titulo == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // POST: Juegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var juego = await _context.Juegos.FindAsync(id);
            _context.Juegos.Remove(juego);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegoExists(string id)
        {
            return _context.Juegos.Any(e => e.Titulo == id);
        }
    }
}
