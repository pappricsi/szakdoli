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
    public class TermeksController : Controller
    {
        private readonly RaktarContext _context;

        public TermeksController(RaktarContext context)
        {
            _context = context;
        }

        // GET: Termeks
        public async Task<IActionResult> Index()
        {
            var raktarContext = _context.Termekek.Include(t => t.Lokacio).Include(t => t.Tipus);
            return View(await raktarContext.ToListAsync());
        }

        // GET: Termeks/Details/5
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

        // GET: Termeks/Create
        public IActionResult Create()
        {
            ViewData["LokacioId"] = new SelectList(_context.Lokaciok, "LokacioId", "LokacioId");
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusNev", "TipusNev");
            return View();
        }

        // POST: Termeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermekID,Suly,LokacioId,TermekTipusId,Betarazva")] Termek termek)
        {
            termek.Betarazva = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(termek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LokacioId"] = new SelectList(_context.Lokaciok.Where(l=>l.Foglalt==false), "LokacioId", "LokacioId", termek.LokacioId);
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusNev", "TipusNev", termek.TermekTipusId);
            var lokacio = _context.Lokaciok.FirstOrDefault(l => l.LokacioId == termek.LokacioId);

            if(lokacio != null)
            {
                lokacio.Foglalt = true;
                _context.Update(lokacio);
                _context.SaveChanges();
            }

            var Curruser = _context.Alkalmazottak.FirstOrDefault(a => a.UserName == User.Identity.Name);
            var tip = _context.TermekTipusok.FirstOrDefault(t => t.TipusNev == termek.TermekTipusId);
            Func<Keszlet, bool> expression = g => g.RaktarId == Curruser.Raktar.RaktarId && g.TermekTipus == tip;
            var keszlet = _context.Keszlet.FirstOrDefault(expression);

            
            if (keszlet != null)
            {
                int db = keszlet.Mennyiseg;
                db++;
                keszlet.Mennyiseg = db;
                _context.Update(keszlet);
                _context.SaveChanges();
            }


            return View(termek);
        }

        // GET: Termeks/Edit/5
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
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusNev", "TipusNev", termek.TermekTipusId);
            return View(termek);
        }

        // POST: Termeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermekID,Suly,LokacioId,TermekTipusId,Betarazva")] Termek termek)
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
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusNev", "TipusNev", termek.TermekTipusId);
            return View(termek);
        }

        // GET: Termeks/Delete/5
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

        // POST: Termeks/Delete/5
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


        public async Task<IActionResult> Kitar(string TermekTipus,int mennyiseg)
        {
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusNev", "TipusNev", TermekTipus);
            return View();
        }

       
    }
}
