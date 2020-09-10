using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TextilesMedicosJDJ.Data;
using TextilesMedicosJDJ.Models;

namespace TextilesMedicosJDJ
{
    public class ProduccionsController : Controller
    {
        private readonly ventasContext _context;

        public ProduccionsController(ventasContext context)
        {
            _context = context;
        }
        
        // GET: Produccions
        public async Task<IActionResult> Index()
        {
            

            return View(await _context.Produccion.ToListAsync());
        }

        // GET: Produccions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // GET: Produccions/Create
        public IActionResult Create()
        {
            List<MateriaPrima> MPrima = new List<MateriaPrima>() {
        new MateriaPrima(){ Descripcion="tela",Color="blanca",Cantidad=20,UnidadMedición="Metros",PrecioXunidadMedicion=1.20},
        new MateriaPrima(){ Descripcion="tela",Color="fusia",Cantidad=20,UnidadMedición="Metros",PrecioXunidadMedicion=1.50},
        new MateriaPrima(){ Descripcion="tela",Color="alivo",Cantidad=50,UnidadMedición="Metros",PrecioXunidadMedicion=1.30},
        new MateriaPrima(){ Descripcion="hilo",Color="negro",Cantidad=30,UnidadMedición="rollos",PrecioXunidadMedicion=2.00},
        new MateriaPrima(){ Descripcion="hilo",Color="blanco",Cantidad=70,UnidadMedición="rollos",PrecioXunidadMedicion=1.50},
        new MateriaPrima(){ Descripcion="hilo",Color="cian",Cantidad=70,UnidadMedición="rollos",PrecioXunidadMedicion=1.50},
        new MateriaPrima(){ Descripcion="cierres",Color="cian",Cantidad=170,UnidadMedición="unidad",PrecioXunidadMedicion=1.50},
        new MateriaPrima(){ Descripcion="cierres",Color="blanco",Cantidad=170,UnidadMedición="unidad",PrecioXunidadMedicion=1.50},
        };
            List<SelectListItem> valores = new List<SelectListItem>();
            List<SelectListItem> tiproductos = new List<SelectListItem>() { 
            new SelectListItem{Text ="Bata",Value="1"},
            new SelectListItem{Text ="Uniforme Blanco",Value="2"},
            new SelectListItem{Text ="Gorra Quirurjica",Value="1"},
            new SelectListItem{Text ="Uniforme Azul",Value="1"},
            new SelectListItem{Text ="Uniforme verde",Value="1"},
            new SelectListItem{Text ="Uniforme pediatrico",Value="1"},
            new SelectListItem{Text ="Lenceria Paciente",Value="1"},
            };
            foreach (var item in MPrima)
            {
                valores.Add(new SelectListItem
                {
                    Text = item.Descripcion + item.Color,
                    Value = item.Cantidad.ToString()
                }) ;
            };
            ViewBag.MateriaPrima = valores;
            ViewBag.Productos = tiproductos;
            ViewBag.MateriaCompleta = MPrima;
            return View();
        }

        // POST: Produccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,MyProperty,TipoProducto,PrecioAproximado,FechaProducción,CantidadProduccion")] Produccion produccion)
        {
            if (ModelState.IsValid)
            {
                produccion.ProductoId = Guid.NewGuid();
                _context.Add(produccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produccion);
        }

        // GET: Produccions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion.FindAsync(id);
            if (produccion == null)
            {
                return NotFound();
            }
            return View(produccion);
        }

        // POST: Produccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductoId,MyProperty,TipoProducto,PrecioAproximado,FechaProducción,CantidadProduccion")] Produccion produccion)
        {
            if (id != produccion.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduccionExists(produccion.ProductoId))
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
            return View(produccion);
        }

        // GET: Produccions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // POST: Produccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produccion = await _context.Produccion.FindAsync(id);
            _context.Produccion.Remove(produccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduccionExists(Guid id)
        {
            return _context.Produccion.Any(e => e.ProductoId == id);
        }
    }
}
