using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uppgift2.DbContext;
using Uppgift2.Models;

namespace Uppgift2.Controllers
{
    public class GenrasController : Controller
    {
        private readonly GenraContext _context;

        public GenrasController(GenraContext context)
        {
            _context = context;
        }

        // GET: Genras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genra.ToListAsync());
        }

        // GET: Genras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genra = await _context.Genra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genra == null)
            {
                return NotFound();
            }

            return View(genra);
        }

        // GET: Genras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Author")] Genra genra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genra);
        }

        // GET: Genras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genra = await _context.Genra.FindAsync(id);
            if (genra == null)
            {
                return NotFound();
            }
            return View(genra);
        }

        // POST: Genras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Author")] Genra genra)
        {
            if (id != genra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenraExists(genra.Id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genra);
        }

        // GET: Genras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genra = await _context.Genra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genra == null)
            {
                return NotFound();
            }

            return View(genra);
        }

        // POST: Genras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genra = await _context.Genra.FindAsync(id);
            _context.Genra.Remove(genra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenraExists(int id)
        {
            return _context.Genra.Any(e => e.Id == id);
        }
    }
}
