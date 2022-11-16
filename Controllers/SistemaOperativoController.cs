using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tpLabo4_usarEste_.Models;

namespace tpLabo4_usarEste_.Controllers
{
    public class SistemaOperativoController : Controller
    {
        private readonly AppDbContext _context;

        public SistemaOperativoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SistemaOperativo
        public async Task<IActionResult> Index()
        {
              return View(await _context.SistemaOperativo.ToListAsync());
        }

        // GET: SistemaOperativo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SistemaOperativo == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativo
                .FirstOrDefaultAsync(m => m.id == id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }

            return View(sistemaOperativo);
        }

        // GET: SistemaOperativo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SistemaOperativo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Descripcion")] SistemaOperativo sistemaOperativo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistemaOperativo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sistemaOperativo);
        }

        // GET: SistemaOperativo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SistemaOperativo == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativo.FindAsync(id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }
            return View(sistemaOperativo);
        }

        // POST: SistemaOperativo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Descripcion")] SistemaOperativo sistemaOperativo)
        {
            if (id != sistemaOperativo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistemaOperativo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemaOperativoExists(sistemaOperativo.id))
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
            return View(sistemaOperativo);
        }

        // GET: SistemaOperativo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SistemaOperativo == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativo
                .FirstOrDefaultAsync(m => m.id == id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }

            return View(sistemaOperativo);
        }

        // POST: SistemaOperativo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SistemaOperativo == null)
            {
                return Problem("Entity set 'AppDbContext.SistemaOperativo'  is null.");
            }
            var sistemaOperativo = await _context.SistemaOperativo.FindAsync(id);
            if (sistemaOperativo != null)
            {
                _context.SistemaOperativo.Remove(sistemaOperativo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SistemaOperativoExists(int id)
        {
          return _context.SistemaOperativo.Any(e => e.id == id);
        }
    }
}
