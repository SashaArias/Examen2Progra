using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen2Progra.Models;

namespace Examen2Progra.Controllers
{
    public class MetasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método privado para cargar listas de enums en ViewData (opcional)
        private void PopulateEnumLists()
        {
            ViewData["CategoriaList"] = new SelectList(Enum.GetValues(typeof(Categoria)));
            ViewData["PrioridadList"] = new SelectList(Enum.GetValues(typeof(Prioridad)));
            ViewData["EstadoMetaList"] = new SelectList(Enum.GetValues(typeof(EstadoMeta)));
        }

        // GET: Metas
        public async Task<IActionResult> Index()
        {
            // Se incluye la relación para poder acceder a las tareas asociadas si es necesario.
            return View(await _context.Metas.Include(m => m.Tareas).ToListAsync());
        }

        // GET: Metas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            // Incluye las tareas asociadas para mostrarlas en la vista de detalles.
            var meta = await _context.Metas.Include(m => m.Tareas)
                                           .FirstOrDefaultAsync(m => m.Id == id);
            if (meta == null)
                return NotFound();

            return View(meta);
        }

        // GET: Metas/Create
        public IActionResult Create()
        {
            PopulateEnumLists();
            return View();
        }

        // POST: Metas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Categoria,FechaCreacion,FechaLimite,Prioridad,Estado")] Meta meta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateEnumLists();
            return View(meta);
        }

        // GET: Metas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var meta = await _context.Metas.FindAsync(id);
            if (meta == null)
                return NotFound();

            PopulateEnumLists();
            return View(meta);
        }

        // POST: Metas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Categoria,FechaCreacion,FechaLimite,Prioridad,Estado")] Meta meta)
        {
            if (id != meta.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetaExists(meta.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateEnumLists();
            return View(meta);
        }

        // GET: Metas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var meta = await _context.Metas.FirstOrDefaultAsync(m => m.Id == id);
            if (meta == null)
                return NotFound();

            return View(meta);
        }

        // POST: Metas/Delete/5  
        // Solo elimina si la meta está en estado "Completada"
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meta = await _context.Metas.FindAsync(id);
            if (meta != null)
            {
                if (meta.Estado != EstadoMeta.Completada)
                {
                    ModelState.AddModelError("", "Solo se pueden eliminar metas que estén completadas.");
                    return View("Delete", meta);
                }
                _context.Metas.Remove(meta);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MetaExists(int id)
        {
            return _context.Metas.Any(e => e.Id == id);
        }
    }
}
