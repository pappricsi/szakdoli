using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szakdoli.DAL;
using Szakdoli.Models;

namespace Szakdoli.Controllers
{
    public class RaktarsController : Controller
    {
        private readonly RaktarContext _context;

        public RaktarsController(RaktarContext context)
        {
            _context = context;
        }

        // GET: Raktars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Raktarak.ToListAsync());
        }

        // GET: Raktars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raktar = await _context.Raktarak
                .FirstOrDefaultAsync(m => m.RaktarId == id);
            if (raktar == null)
            {
                return NotFound();
            }

            return View(raktar);
        }

        // GET: Raktars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Raktars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RaktarId,Nev,Cim,TelefonSZam")] Raktar raktar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raktar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raktar);
        }

        // GET: Raktars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raktar = await _context.Raktarak.FindAsync(id);
            if (raktar == null)
            {
                return NotFound();
            }
            return View(raktar);
        }

        // POST: Raktars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RaktarId,Nev,Cim,TelefonSZam")] Raktar raktar)
        {
            if (id != raktar.RaktarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raktar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaktarExists(raktar.RaktarId))
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
            return View(raktar);
        }

        // GET: Raktars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raktar = await _context.Raktarak
                .FirstOrDefaultAsync(m => m.RaktarId == id);
            if (raktar == null)
            {
                return NotFound();
            }

            return View(raktar);
        }

        // POST: Raktars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raktar = await _context.Raktarak.FindAsync(id);
            _context.Raktarak.Remove(raktar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaktarExists(int id)
        {
            return _context.Raktarak.Any(e => e.RaktarId == id);
        }
    }
}
