using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica3.Models;

namespace Practica3.Controllers
{
    public class equiposController : Controller
    {
        private readonly EquiposDbContext _context;

        public equiposController(EquiposDbContext context)
        {
            _context = context;
        }

        // GET: equipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.equipos.ToListAsync());
        }

        // GET: equipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipos = await _context.equipos
                .FirstOrDefaultAsync(m => m.id_equipo == id);
            if (equipos == null)
            {
                return NotFound();
            }

            return View(equipos);
        }

        // GET: equipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: equipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_equipo,nombre,Tipo_equipo,id_marcas,anio_compra,vida_util,descripcion,modelo,Costo")] equipos equipos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipos);
        }

        // GET: equipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipos = await _context.equipos.FindAsync(id);
            if (equipos == null)
            {
                return NotFound();
            }
            return View(equipos);
        }

        // POST: equipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_equipo,nombre,Tipo_equipo,id_marcas,anio_compra,vida_util,descripcion,modelo,Costo")] equipos equipos)
        {
            if (id != equipos.id_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!equiposExists(equipos.id_equipo))
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
            return View(equipos);
        }

        // GET: equipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipos = await _context.equipos
                .FirstOrDefaultAsync(m => m.id_equipo == id);
            if (equipos == null)
            {
                return NotFound();
            }

            return View(equipos);
        }

        // POST: equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipos = await _context.equipos.FindAsync(id);
            if (equipos != null)
            {
                _context.equipos.Remove(equipos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool equiposExists(int id)
        {
            return _context.equipos.Any(e => e.id_equipo == id);
        }
    }
}
