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
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Szakdoli.Controllers
{
    [Authorize]
    public class TermeksController : Controller
    {
        private readonly RaktarContext _context;
        private UserManager<Alkalmazott> userMgr;

        public TermeksController(RaktarContext context, UserManager<Alkalmazott> userManager)
        {
            _context = context;
            userMgr = userManager;
        }

        

        // GET: /Termeks
        public async Task<IActionResult> Index(string search)
        {
            
            var raktarContext = _context.Termekek.Include(t => t.Lokacio).Include(t => t.Tipus);
            if (!User.IsInRole("Admin"))
            {
                Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User).ToString());
                raktarContext = raktarContext.Where(t => t.Lokacio.RaktarID == alkalmazott.RaktarID).Include(t => t.Lokacio).Include(t => t.Tipus);
            }

            if (!String.IsNullOrEmpty(search))
            {
               var eredmeny = raktarContext.Where(s => s.Tipus.TipusNev.Contains(search)
                || s.Lokacio.LokacioNev.Contains(search)
                || s.Betarazva.ToString().Contains(search)
                || s.TermekID.ToString().Contains(search)
               );
                return View(eredmeny.ToList());
            }
            
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
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public IActionResult Create()
        {
            ViewData["LokacioId"] = new SelectList(_context.Lokaciok, "LokacioId", "LokacioId");
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusID");
            return View();
        }

        // POST: Termeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Raktar vezeto")]
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
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User).ToString());
            ViewData["LokacioId"] = new SelectList(_context.Lokaciok.Where(t => t.RaktarID==alkalmazott.RaktarID), "LokacioId", "LokacioId", termek.LokacioId);
            ViewData["TermekTipusId"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusID", termek.TermekTipusId);
            return View(termek);
        }

        // POST: Termeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermekID,LokacioId,TermekTipusId,Betarazva")] Termek termek)
        {
            Alkalmazott felh = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User).ToString());
            if (id != termek.TermekID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var uj = _context.Lokaciok.FirstOrDefault(l => l.LokacioId == termek.LokacioId);
                    var ter = _context.Termekek.FirstOrDefault(t => t.TermekID == id);
                    var regi = _context.Lokaciok.FirstOrDefault(t => t.LokacioId == ter.LokacioId);

                    uj.Foglalt = true;
                    regi.Foglalt = false;
                    Log bejegyzes = new Log { Datum = DateTime.Now, Letrehozo = felh, Leiras = ter.TermekID.ToString() + " azonosítójú termék " + regi.LokacioNev + " lokációból " + uj.LokacioNev + " lokációra áthelyezve" };
                    
                    _context.Update(termek);
                    _context.Add(bejegyzes);
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

        // GET: Termeks/Delete/5
        [Authorize(Roles = "Admin,Raktar vezeto")]
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
        [Authorize(Roles = "Admin,Raktar vezeto")]
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
            ViewData["TermekTipusok"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusNev");
            ViewData["Lokaciok"] = new SelectList(_context.Lokaciok.Where(l => l.Foglalt == false && l.RaktarID == alkalmazott.RaktarID), "LokacioId", "LokacioNev");
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Betar(Termek model)
        {
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            ViewData["TermekTipusok"] = new SelectList(_context.TermekTipusok, "TipusID", "TipusNev", model.TermekTipusId);
            ViewData["Lokaciok"] = new SelectList(_context.Lokaciok.Where(l => l.Foglalt == false && l.RaktarID==alkalmazott.RaktarID), "LokacioId", "LokacioNev",model.LokacioId);
            Termek uj = new Termek { LokacioId = model.LokacioId, Betarazva = DateTime.Now, TermekTipusId = model.TermekTipusId, };
            ModelState.AddModelError("Tipus","Ha még nem tette meg vegyen fel termék típust mielőtt betárolná a terméket !");
            var tipus = uj.Tipus;
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
                var id = _context.Termekek.FirstOrDefault(t => t.Lokacio == uj.Lokacio && t.Betarazva == uj.Betarazva).TermekID;
                Log bejegyzes = new Log { Datum = DateTime.Now, Letrehozo = alkalmazott, Leiras = "Betárazva " + id.ToString() + " azonosítóju termék " + uj.Lokacio.LokacioNev + " tárhelyre" };
                _context.Add(bejegyzes);
                await _context.SaveChangesAsync();
            }

            Termek betar = _context.Termekek.FirstOrDefault(t => t.Lokacio == uj.Lokacio && t.Betarazva == uj.Betarazva);
            betar.Tipus = _context.TermekTipusok.FirstOrDefault(t => t.TipusID == betar.TermekTipusId);
            TempData["betar"] = JsonConvert.SerializeObject(betar);
            return RedirectToAction("BetarDetails");
        }

        public IActionResult BetarDetails()
        {
            Termek modell = JsonConvert.DeserializeObject<Termek>(TempData["betar"].ToString());

            return View(modell);
        }

        public IActionResult Kitar()
        {
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            IEnumerable<TermekTipus> ls = _context.Keszlet
               .Where(k => k.Mennyiseg != 0 && k.RaktarId == alkalmazott.RaktarID)
               .Select(k => k.TermekTipus)
               .ToList();
            ModelState.AddModelError("Ures", "Jelenleg nem található termék a készleten !");
            ViewData["TermekTipus"] = new SelectList(ls, "TipusID", "TipusNev");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kitar(Termek termek)
        {
            
            Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
            IEnumerable<TermekTipus> ls = await _context.Keszlet
               .Where(k => k.Mennyiseg != 0 && k.RaktarId == alkalmazott.RaktarID)
               .Select(k => k.TermekTipus)
               .ToListAsync();

            ViewData["TermekTipus"] = new SelectList(ls, "TipusID", "TipusNev",termek.TermekTipusId);
            var tip = _context.TermekTipusok.FirstOrDefault(t => t.TipusID == termek.TermekTipusId);
            Termek kitar = _context.Termekek.Where(t => t.TermekTipusId == tip.TipusID).OrderBy(x => x.Betarazva).First();
            var lok = _context.Lokaciok.FirstOrDefault(l => l.LokacioId == kitar.LokacioId);
            Termek mutat = new Termek { Betarazva = kitar.Betarazva, Lokacio = kitar.Lokacio, Tipus = kitar.Tipus };
            TempData["kitar"] = JsonConvert.SerializeObject(mutat);
            if (ModelState.IsValid)
            {
                Log bejegyzes = new Log { Datum = DateTime.Now, Letrehozo = alkalmazott, 
                    Leiras = "Kitárazva " + kitar.TermekID.ToString() + " azonosítóju termék " + kitar.Lokacio.LokacioNev+" tárhelyről"};
                _context.Add(bejegyzes);

                _context.Termekek.Remove(kitar);
               
                lok.Foglalt = false;
                _context.Update(lok);

                var keszlet = _context.Keszlet.FirstOrDefault(k => k.RaktarId == alkalmazott.RaktarID && k.TermekTipusId == tip.TipusID);
                int db = keszlet.Mennyiseg;
                db--;
                keszlet.Mennyiseg = db;
                _context.Update(keszlet);

                

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("KitarDetails");
        }

        public  IActionResult KitarDetails()
        {
            Termek modell = JsonConvert.DeserializeObject<Termek>(TempData["kitar"].ToString());

            return View(modell);
        }


    }
}
