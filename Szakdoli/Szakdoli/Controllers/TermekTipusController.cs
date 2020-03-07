using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szakdoli.DAL;
using Szakdoli.Models;

namespace Szakdoli.Controllers
{
    public class TermekTipusController : Controller
    {
        private readonly RaktarContext _context;

        public TermekTipusController(RaktarContext context)
        {
            _context = context;
        }

        // GET: TermekTipus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TermekTipusok.ToListAsync());
        }

        // GET: TermekTipus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termekTipus = await _context.TermekTipusok
                .FirstOrDefaultAsync(m => m.TipusID == id);
            if (termekTipus == null)
            {
                return NotFound();
            }

            return View(termekTipus);
        }

        // GET: TermekTipus/Create
        [Authorize(Roles="Admin,Raktar vezeto")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TermekTipus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipusID,TipusNev,Suly")] TermekTipus termekTipus)
        {
            List<Raktar> ls = _context.Raktarak.ToList();
            if (ModelState.IsValid && !( _context.TermekTipusok.Any(t => t.TipusNev==termekTipus.TipusNev)))
            {
                

                _context.Add(termekTipus);
                await _context.SaveChangesAsync();
                var id = _context.TermekTipusok.FirstOrDefault(t => t.TipusNev == termekTipus.TipusNev).TipusID;
                foreach (var item in ls)
                {
                    Keszlet temp = new Keszlet { RaktarId = item.RaktarId, TermekTipusId = id, Mennyiseg = 0 };
                    _context.Add(temp);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(termekTipus);
        }

        // GET: TermekTipus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termekTipus = await _context.TermekTipusok.FindAsync(id);
            if (termekTipus == null)
            {
                return NotFound();
            }
            return View(termekTipus);
        }

        // POST: TermekTipus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipusID,TipusNev,Suly")] TermekTipus termekTipus)
        {
            if (id != termekTipus.TipusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termekTipus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermekTipusExists(termekTipus.TipusID))
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
            return View(termekTipus);
        }

        // GET: TermekTipus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termekTipus = await _context.TermekTipusok
                .FirstOrDefaultAsync(m => m.TipusID == id);
            if (termekTipus == null)
            {
                return NotFound();
            }

            return View(termekTipus);
        }

        // POST: TermekTipus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var termekTipus = await _context.TermekTipusok.FindAsync(id);
            _context.TermekTipusok.Remove(termekTipus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermekTipusExists(int id)
        {
            return _context.TermekTipusok.Any(e => e.TipusID == id);
        }
    }
}
