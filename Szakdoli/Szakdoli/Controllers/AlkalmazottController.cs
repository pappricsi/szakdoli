using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Szakdoli.DAL;
using Szakdoli.Models;
using Szakdoli.ViewModels;

namespace Szakdoli.Controllers
{

    [Authorize]
    public class AlkalmazottController : Controller
    {

        private UserManager<Alkalmazott> userMgr;
        private SignInManager<Alkalmazott> signInMgr;
        private RoleManager<IdentityRole> roleMgr;
        private readonly RaktarContext _context;
        

        public AlkalmazottController(UserManager<Alkalmazott> userManager,
            SignInManager<Alkalmazott> signInManager, RaktarContext context,
            RoleManager<IdentityRole> roleManager)
        {
            userMgr = userManager;
            signInMgr = signInManager;
            roleMgr = roleManager;
            _context = context;
        }
        // GET: Alkalmazott
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public async Task<IActionResult> Index(string search)
        {
            var users = _context.Alkalmazottak.ToList();

            if (!String.IsNullOrEmpty(search))
            {
                var eredmeny = users.Where(s => s.RaktarID.ToString().Contains(search)
                 || s.TeljesNev.Contains(search)
                 || s.UserName.Contains(search)
                 || s.Id.Contains(search)
                );
                return View(eredmeny.ToList());
            }

            return View(users);
        }

        // GET: Alkalmazott/Details/5
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alkalmazott/Create
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alkalmazott/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Alkalmazott/Edit/5
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alkalmazott/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Alkalmazott/Delete/5
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alkalmazott = await _context.Alkalmazottak.FindAsync(id);
            var role = userMgr.GetRolesAsync(alkalmazott);
            DeleteModel model = new DeleteModel { Id = alkalmazott.Id, TeljesNev = alkalmazott.TeljesNev, Szerepkor = role.Result[0] };
            if (alkalmazott == null)
            {
                return NotFound();
            }
            return View(model);
            
        }

        // POST: Alkalmazott/Delete/5
        [Authorize(Roles = "Admin,Raktar vezeto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                var alkalmazott = await _context.Alkalmazottak.FindAsync(id);
                await userMgr.DeleteAsync(alkalmazott);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin,Raktar vezeto")]
        public IActionResult CreateUser()
        {
            
            ViewData["RaktarID"] = new SelectList(_context.Raktarak, "Nev", "Nev");
            ViewData["Role"] = new SelectList(_context.Roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Raktar vezeto")]
        public async Task<IActionResult> CreateUser(InputModel input)
        {
           
            ViewData["RaktarID"] = new SelectList(_context.Raktarak, "Nev", "Nev", input.Raktar);
            ViewData["Role"] = new SelectList(_context.Roles, "Name", "Name",input.Role);
            if (ModelState.IsValid)
            {
                var rakt = _context.Raktarak.FirstOrDefault(r => r.Nev == input.Raktar);
                //var raktar = _context.Raktarak.FirstOrDefault(r => r.Nev == input.Raktar.Nev);
                var alkalmazott = new Alkalmazott { Email = input.Email, RaktarID=rakt.RaktarId,UserName=input.Email.ToUpper(),TeljesNev=input.TeljesNev,EmailConfirmed=true };
                IdentityResult result = await userMgr.CreateAsync(alkalmazott,input.Password);
                IdentityResult result2 = await userMgr.AddToRoleAsync(alkalmazott, input.Role);
                if (result.Succeeded && result2.Succeeded)
                    return RedirectToAction("Index");
                else
                    return NotFound();
            }
            return View("Index");
        }

        [Authorize(Roles = "Admin,Raktar Vezeto")]
        public IActionResult CreateRole()
        {
            return View();
        }




        [HttpPost]
        [Authorize(Roles = "Admin,Raktar Vezeto")]
        public async Task<IActionResult> CreateRole([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleMgr.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            return View(name);
        }
    }
}