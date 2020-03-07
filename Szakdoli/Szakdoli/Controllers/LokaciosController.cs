using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szakdoli.DAL;
using Szakdoli.Models;

namespace Szakdoli.Controllers
{
    public class LokaciosController : Controller
    {
        private readonly RaktarContext _context;
        private UserManager<Alkalmazott> userMgr;

        public LokaciosController(RaktarContext context, UserManager<Alkalmazott> userManager)
        {
            _context = context;
            userMgr = userManager;
        }

        // GET: Lokacios
        public async Task<IActionResult> Index()
        {
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            var raktarContext = _context.Lokaciok.Include(l => l.Raktar).Where(x => x.RaktarID==alkalmazott.RaktarID);
            return View(await raktarContext.ToListAsync());
        }

        // GET: Lokacios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacio = await _context.Lokaciok
                .Include(l => l.Raktar)
                .FirstOrDefaultAsync(m => m.LokacioId == id);
            if (lokacio == null)
            {
                return NotFound();
            }

            return View(lokacio);
        }

        // GET: Lokacios/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["RaktarID"] = new SelectList(_context.Raktarak, "RaktarId", "RaktarId");
            return View();
        }

        // POST: Lokacios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LokacioId,LokacioNev,RaktarID,Foglalt")] Lokacio lokacio)
        {
            lokacio.Foglalt = false;
            if (ModelState.IsValid)
            {
                _context.Add(lokacio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RaktarID"] = new SelectList(_context.Raktarak, "RaktarId", "RaktarId", lokacio.RaktarID);
            return View(lokacio);
        }

        // GET: Lokacios/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacio = await _context.Lokaciok.FindAsync(id);
            if (lokacio == null)
            {
                return NotFound();
            }
            ViewData["RaktarID"] = new SelectList(_context.Raktarak, "RaktarId", "RaktarId", lokacio.RaktarID);
            return View(lokacio);
        }

        // POST: Lokacios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LokacioId,LokacioNev,RaktarID,Foglalt")] Lokacio lokacio)
        {
            if (id != lokacio.LokacioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokacio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokacioExists(lokacio.LokacioId))
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
            ViewData["RaktarID"] = new SelectList(_context.Raktarak, "RaktarId", "RaktarId", lokacio.RaktarID);
            return View(lokacio);
        }

        // GET: Lokacios/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacio = await _context.Lokaciok
                .Include(l => l.Raktar)
                .FirstOrDefaultAsync(m => m.LokacioId == id);
            if (lokacio == null)
            {
                return NotFound();
            }

            return View(lokacio);
        }

        // POST: Lokacios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lokacio = await _context.Lokaciok.FindAsync(id);
            _context.Lokaciok.Remove(lokacio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokacioExists(int id)
        {
            return _context.Lokaciok.Any(e => e.LokacioId == id);
        }
    }
}
