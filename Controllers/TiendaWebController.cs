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
    public class TiendaWebController : Controller
    {
        private readonly AppDbContext _context;

        public TiendaWebController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TiendaWeb
        public async Task<IActionResult> Index()
        {
              return View(await _context.TiendaWEbs.ToListAsync());
        }

        // GET: TiendaWeb/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiendaWEbs == null)
            {
                return NotFound();
            }

            var tiendaWEb = await _context.TiendaWEbs
                .FirstOrDefaultAsync(m => m.id == id);
            if (tiendaWEb == null)
            {
                return NotFound();
            }

            return View(tiendaWEb);
        }

        // GET: TiendaWeb/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiendaWeb/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombreTienda")] TiendaWEb tiendaWEb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiendaWEb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiendaWEb);
        }

        // GET: TiendaWeb/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiendaWEbs == null)
            {
                return NotFound();
            }

            var tiendaWEb = await _context.TiendaWEbs.FindAsync(id);
            if (tiendaWEb == null)
            {
                return NotFound();
            }
            return View(tiendaWEb);
        }

        // POST: TiendaWeb/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombreTienda")] TiendaWEb tiendaWEb)
        {
            if (id != tiendaWEb.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiendaWEb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendaWEbExists(tiendaWEb.id))
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
            return View(tiendaWEb);
        }

        // GET: TiendaWeb/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiendaWEbs == null)
            {
                return NotFound();
            }

            var tiendaWEb = await _context.TiendaWEbs
                .FirstOrDefaultAsync(m => m.id == id);
            if (tiendaWEb == null)
            {
                return NotFound();
            }

            return View(tiendaWEb);
        }

        // POST: TiendaWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiendaWEbs == null)
            {
                return Problem("Entity set 'AppDbContext.TiendaWEbs'  is null.");
            }
            var tiendaWEb = await _context.TiendaWEbs.FindAsync(id);
            if (tiendaWEb != null)
            {
                _context.TiendaWEbs.Remove(tiendaWEb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiendaWEbExists(int id)
        {
          return _context.TiendaWEbs.Any(e => e.id == id);
        }
    }
}
