using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Szakdoli.DAL;
using Szakdoli.Models;


namespace Szakdoli.Controllers
{
    

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
        public async Task<IActionResult> Index()
        {
            Alkalmazott alkalmazott = new Alkalmazott();
           var users = _context.Alkalmazottak.ToList();
           
            return View(users);
        }

        // GET: Alkalmazott/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alkalmazott/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alkalmazott/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alkalmazott/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alkalmazott/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CreateUser()
        {
            
            ViewData["RaktarID"] = new SelectList(_context.Raktarak, "Nev", "Nev");
            ViewData["Role"] = new SelectList(_context.Roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(InputModel input)
        {
           
            ViewData["RaktarID"] = new SelectList(_context.Raktarak, "Nev", "Nev", input.Raktar);
            ViewData["Role"] = new SelectList(_context.Roles, "Name", "Name",input.Role);
            if (ModelState.IsValid)
            {
                var rakt = _context.Raktarak.FirstOrDefault(r => r.Nev == input.Raktar);
                //var raktar = _context.Raktarak.FirstOrDefault(r => r.Nev == input.Raktar.Nev);
                var alkalmazott = new Alkalmazott { Email = input.Email, RaktarID=rakt.RaktarId,UserName=input.Email.ToUpper(),TeljesNev=input.TeljesNev };
                IdentityResult result = await userMgr.CreateAsync(alkalmazott,input.Password);
                IdentityResult result2 = await userMgr.AddToRoleAsync(alkalmazott, input.Role);
                if (result.Succeeded && result2.Succeeded)
                    return RedirectToAction("Index");
                else
                    return NotFound();
            }
            return View("Index");
        }

        public IActionResult CreateRole()
        {
            return View();
        }




        [HttpPost]
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