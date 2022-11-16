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
    public class CelularController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment env;

        public CelularController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
        }

        // GET: Celular
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Celular.Include(c => c.SistemaOperativo).Include(c => c.marca);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Celular/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Celular == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular
                .Include(c => c.SistemaOperativo)
                .Include(c => c.marca)
                .FirstOrDefaultAsync(m => m.id == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // GET: Celular/Create
        public IActionResult Create()
        {
            ViewData["sistemaOperativoId"] = new SelectList(_context.SistemaOperativo, "id", "id");
            ViewData["marcaId"] = new SelectList(_context.Marca, "id", "id");
            return View();
        }

        // POST: Celular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,modelo,precio,descripcion,foto,marcaId,sistemaOperativoId")] Celular celular)
        {
            if (ModelState.IsValid)
            {
                var archivo = HttpContext.Request.Form.Files;
                if(archivo != null && archivo.Count > 0)
                {
                    var archivoFoto = archivo[0];
                    //var pathDestino = Path.Combine(env.WebRootPath, "Imagenes\\Celular");
                    if(archivoFoto.Length > 0)

                    {
                        var pathDestino = Path.Combine(env.WebRootPath, "Imagenes\\Celular");
                        var archivodestino = Guid.NewGuid().ToString();
                         archivodestino = archivodestino.Replace("-", "");
                       archivodestino= Path.GetExtension(archivoFoto.FileName);

                        using (var fileStream = new FileStream(Path.Combine(pathDestino, archivodestino), FileMode.Create))
                        {
                            archivoFoto.CopyTo(fileStream);
                            celular.foto = archivodestino;
                        };

                    }
                    
                }


                _context.Add(celular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["sistemaOperativoId"] = new SelectList(_context.SistemaOperativo, "id", "id", celular.sistemaOperativoId);
            ViewData["marcaId"] = new SelectList(_context.Marca, "id", "id", celular.marcaId);
            return View(celular);
        }

        // GET: Celular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Celular == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular.FindAsync(id);
            if (celular == null)
            {
                return NotFound();
            }
            ViewData["sistemaOperativoId"] = new SelectList(_context.SistemaOperativo, "id", "id", celular.sistemaOperativoId);
            ViewData["marcaId"] = new SelectList(_context.Marca, "id", "id", celular.marcaId);
            return View(celular);
        }

        // POST: Celular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,modelo,precio,descripcion,foto,marcaId,sistemaOperativoId")] Celular celular)
        {
            if (id != celular.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelularExists(celular.id))
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
            ViewData["sistemaOperativoId"] = new SelectList(_context.SistemaOperativo, "id", "id", celular.sistemaOperativoId);
            ViewData["marcaId"] = new SelectList(_context.Marca, "id", "id", celular.marcaId);
            return View(celular);
        }

        // GET: Celular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Celular == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular
                .Include(c => c.SistemaOperativo)
                .Include(c => c.marca)
                .FirstOrDefaultAsync(m => m.id == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // POST: Celular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Celular == null)
            {
                return Problem("Entity set 'AppDbContext.Celular'  is null.");
            }
            var celular = await _context.Celular.FindAsync(id);
            if (celular != null)
            {
                _context.Celular.Remove(celular);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelularExists(int id)
        {
          return _context.Celular.Any(e => e.id == id);
        }
    }
}
