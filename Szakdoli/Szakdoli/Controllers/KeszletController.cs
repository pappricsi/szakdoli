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
    [Authorize]
    public class KeszletController : Controller
    {
        private readonly RaktarContext _context;
        private UserManager<Alkalmazott> userMgr;

        public KeszletController(RaktarContext context, UserManager<Alkalmazott> userManager)
        {
            _context = context;
            userMgr = userManager;
        }

        // GET: Keszlet
        public async Task<IActionResult> Index()
        {
           
            var raktarContext = _context.Keszlet.Include(k => k.Raktar).Include(k => k.TermekTipus);
            if (!User.IsInRole("Admin"))
            {
                Alkalmazott alkalmazott = _context.Alkalmazottak.FirstOrDefault(a => a.Id == userMgr.GetUserId(User));
                raktarContext = raktarContext.Where(k => k.RaktarId == alkalmazott.RaktarID).Include(k => k.Raktar).Include(k => k.TermekTipus);
            }

            return View(await raktarContext.ToListAsync());
        }

        // GET: Keszlet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keszlet = await _context.Keszlet
                .Include(k => k.Raktar)
                .Include(k => k.TermekTipus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keszlet == null)
            {
                return NotFound();
            }

            return View(keszlet);
        }

       

        // GET: Keszlet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keszlet = await _context.Keszlet
                .Include(k => k.Raktar)
                .Include(k => k.TermekTipus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keszlet == null || keszlet.Mennyiseg>0)
            {
                return NotFound();
            }

            return View(keszlet);
        }

        // POST: Keszlet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keszlet = await _context.Keszlet.FindAsync(id);
            _context.Keszlet.Remove(keszlet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeszletExists(int id)
        {
            return _context.Keszlet.Any(e => e.Id == id);
        }
    }
}
