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
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            ViewData["TermekTipusok"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusID");
            ViewData["Lokaciok"] = new SelectList(_context.Lokaciok.Where(l => l.Foglalt == false && l.RaktarID == alkalmazott.RaktarID), "LokacioId", "LokacioNev");
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Betar(Termek model)
        {
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            ViewData["TermekTipusok"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusID", model.TermekTipusId);
            ViewData["Lokaciok"] = new SelectList(_context.Lokaciok.Where(l => l.Foglalt == false && l.RaktarID==alkalmazott.RaktarID), "LokacioId", "LokacioNev",model.LokacioId);
            Termek uj = new Termek { LokacioId = model.LokacioId, Betarazva = DateTime.Now, TermekTipusId = model.TermekTipusId, };
            if (ModelState.IsValid)
            {
                _context.Add(uj);
               

                Keszlet keszlet = _context.Keszlet.First(k => k.RaktarId == alkalmazott.RaktarID && k.TermekTipusId == model.TermekTipusId);
                int db = keszlet.Mennyiseg;
                db++;
                keszlet.Mennyiseg = db;
                _context.Update(keszlet);

                Lokacio lokacio = _context.Lokaciok.FirstOrDefault(l => l.LokacioId == model.LokacioId);
                lokacio.Foglalt = true;
                _context.Update(lokacio);

                await _context.SaveChangesAsync();
            }
            return View(nameof(Betar));
        }

        public IActionResult Kitar()
        {
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            List <Keszlet > ls= _context.Keszlet.Where(k => k.Mennyiseg != 0 && k.RaktarId == alkalmazott.RaktarID).ToList();
            List<TermekTipus> lista = new List<TermekTipus>();
            foreach (var item in ls)
            {
                var tt = _context.TermekTipusok.FirstOrDefault(t => t.TipusID == item.TermekTipusId);
                lista.Add(tt);
            }
            ViewData["TermekTipus"] = new SelectList(lista, "TipusNev", "TipusID");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kitar([Bind("TipusNev")]TermekTipus tipus)
        {
            
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            List<Keszlet> ls = _context.Keszlet.Where(k => k.Mennyiseg != 0 && k.RaktarId == alkalmazott.RaktarID).ToList();
            List<TermekTipus> lista = new List<TermekTipus>();
            foreach (var item in ls)
            {
                var tt = _context.TermekTipusok.FirstOrDefault(t => t.TipusID == item.TermekTipusId);
                lista.Add(tt);
            }
            ViewData["TermekTipus"] = new SelectList(lista, "TipusNev", "TipusID",tipus.TipusID);
            var tip = _context.TermekTipusok.FirstOrDefault(t => t.TipusID == tipus.TipusID);
            Termek termek = _context.Termekek.Where(t => t.TermekTipusId == tip.TipusID).OrderBy(x => x.Betarazva).First();
            var lok = _context.Lokaciok.FirstOrDefault(l => l.LokacioId == termek.LokacioId);

            if (ModelState.IsValid)
            {
                _context.Termekek.Remove(termek);
               
                lok.Foglalt = false;
                _context.Update(lok);

                var keszlet = _context.Keszlet.FirstOrDefault(k => k.RaktarId == alkalmazott.RaktarID && k.TermekTipusId == tip.TipusID);
                int db = keszlet.Mennyiseg;
                db--;
                _context.Update(keszlet);

                await _context.SaveChangesAsync();
            }

            return View(nameof(Kitar));
        }
    }
}
