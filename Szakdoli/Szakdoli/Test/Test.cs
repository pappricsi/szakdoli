using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Szakdoli.Controllers;
using Szakdoli.DAL;
using Szakdoli.Models;

namespace Szakdoli.Test
{
    [TestClass]
    public class Test
    {
        private  RaktarContext _context;
        private UserManager<Alkalmazott> userMgr;
        [TestMethod]
        public async void TestIndexView(RaktarContext context, UserManager<Alkalmazott> userManager)
        {
            _context = context;
            userMgr = userManager;
            var controller = new TermeksController(context,userMgr);
            var result = await controller.Index("") as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
