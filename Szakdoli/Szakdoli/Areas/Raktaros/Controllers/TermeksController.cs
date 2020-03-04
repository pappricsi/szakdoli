using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szakdoli.DAL;
using Szakdoli.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Szakdoli.Areas.Raktaros.Controllers
{
    [Area("Raktaros")]
    public class TermeksController : Controller
    {
        private readonly RaktarContext _context;
        private UserManager<Alkalmazott> userMgr;

        public TermeksController(RaktarContext context, UserManager<Alkalmazott> userManager)
        {
            _context = context;
            userMgr = userManager;
        }

        // GET: Raktaros/Termeks
        public async Task<IActionResult> Index()
        {
            var raktarContext = _context.Termekek.Include(t => t.Lokacio).Include(t => t.Tipus);
            return View(await raktarContext.ToListAsync());
        }

        // GET: Raktaros/Termeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termek = await _context.Termekek
                .Include(t => t.Lokacio)
                .Include(t => t.Tipus)
                .FirstOrDefaultAsync(m => m.TermekID == id);
            if (termek == null)
            {
                return NotFound();
            }

            return View(termek);
        }

        // GET: Raktaros/Termeks/Create
        public IActionResult Create()
        {
            ViewData["LokacioId"] = new SelectList(_context.Lokaciok, "LokacioId", "LokacioId");
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusID");
            return View();
        }

        // POST: Raktaros/Termeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermekID,LokacioId,TermekTipusId,Betarazva")] Termek termek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(termek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LokacioId"] = new SelectList(_context.Lokaciok, "LokacioId", "LokacioId", termek.LokacioId);
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusID", termek.TermekTipusId);
            return View(termek);
        }

        // GET: Raktaros/Termeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termek = await _context.Termekek.FindAsync(id);
            if (termek == null)
            {
                return NotFound();
            }
            ViewData["LokacioId"] = new SelectList(_context.Lokaciok, "LokacioId", "LokacioId", termek.LokacioId);
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusID", termek.TermekTipusId);
            return View(termek);
        }

        // POST: Raktaros/Termeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermekID,LokacioId,TermekTipusId,Betarazva")] Termek termek)
        {
            if (id != termek.TermekID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermekExists(termek.TermekID))
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
            ViewData["LokacioId"] = new SelectList(_context.Lokaciok, "LokacioId", "LokacioId", termek.LokacioId);
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusID", termek.TermekTipusId);
            return View(termek);
        }

        // GET: Raktaros/Termeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termek = await _context.Termekek
                .Include(t => t.Lokacio)
                .Include(t => t.Tipus)
                .FirstOrDefaultAsync(m => m.TermekID == id);
            if (termek == null)
            {
                return NotFound();
            }

            return View(termek);
        }

        // POST: Raktaros/Termeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var termek = await _context.Termekek.FindAsync(id);
            _context.Termekek.Remove(termek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermekExists(int id)
        {
            return _context.Termekek.Any(e => e.TermekID == id);
        }


        public IActionResult Betar()
        {
            ViewData["TermekTipusok"] = new SelectList(_context.TermekTipusok, "TipusNev", "TipusNev");
            ViewData["Lokaciok"] = new SelectList(_context.Lokaciok.Where(l => l.Foglalt == false), "LokacioNev", "LokaciId");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Betar(Termek model)
        {
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            ViewData["TermekTipusok"] = new SelectList(_context.TermekTipusok, "TipusNev", "TpusNev", model.Tipus.TipusNev);
            ViewData["Lokaciok"] = new SelectList(_context.Lokaciok.Where(l => l.Foglalt == false && l.RaktarID==alkalmazott.RaktarID), "LokacioNev", "LokaciId",model.LokacioId);
            var tipus = _context.TermekTipusok.FirstOrDefault(t => t.TipusNev == model.Tipus.TipusNev);
            var lokacio = _context.Lokaciok.FirstOrDefault(l => l.LokacioId == model.LokacioId);
            Termek uj = new Termek { LokacioId = lokacio.LokacioId, Betarazva = DateTime.Now, TermekTipusId = tipus.TipusID };
            if (ModelState.IsValid)
            {
                _context.Add(uj);
               

                var keszlet = _context.Keszlet.FirstOrDefault(k => k.RaktarId == alkalmazott.RaktarID && k.TermekTipusId == tipus.TipusID);
                int db = keszlet.Mennyiseg;
                db++;
                _context.Update(keszlet);

                lokacio.Foglalt = false;
                _context.Update(lokacio);

                await _context.SaveChangesAsync();
            }
            return View();
        }
    }
}
