using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TextilesMedicosJDJ.Data;
using TextilesMedicosJDJ.Models;

namespace TextilesMedicosJDJ.Controllers
{
    public class ventasController : Controller
    {
        private readonly ventasContext _context;

        public ventasController(ventasContext context)
        {
            _context = context;
        }

        // GET: ventas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ventas.ToListAsync());
        }
        [Authorize]
        // GET: ventas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.ventas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }
        [Authorize]
        // GET: ventas/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descripcion,Cantidad,Precio,Total")] ventas ventas)
        {
            if (ModelState.IsValid)
            {
                ventas.ID = Guid.NewGuid();
                _context.Add(ventas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventas);
        }
        [Authorize]
        // GET: ventas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }
            return View(ventas);
        }
        [Authorize]
        // POST: ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Descripcion,Cantidad,Precio,Total")] ventas ventas)
        {
            if (id != ventas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ventasExists(ventas.ID))
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
            return View(ventas);
        }
        [Authorize]
        // GET: ventas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.ventas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }
        [Authorize]
        // POST: ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ventas = await _context.ventas.FindAsync(id);
            _context.ventas.Remove(ventas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ventasExists(Guid id)
        {
            return _context.ventas.Any(e => e.ID == id);
        }
    }
}
