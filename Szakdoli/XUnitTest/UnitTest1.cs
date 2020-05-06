using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Szakdoli.Controllers;
using Szakdoli.DAL;
using Szakdoli.Models;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {

        [Fact]
        public void TermekIndexTest()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new TermeksController(context, userMgr);
            //Act
            var result = controller.Index("");
            //Assert
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public void TermekDetailsTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new TermeksController(context, userMgr);
            var result = controller.Details(null);
            Assert.True(result.IsCompletedSuccessfully);
        }


        [Fact]
        public void TermekEditTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new TermeksController(context, userMgr);
            var result = controller.Edit(null);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public void KeszletIndexTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new KeszletController(context, userMgr);
            var result = controller.Index();
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public void KeszletDetailsTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new KeszletController(context, userMgr);
            var result = controller.Details(null);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public void LogIndexTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new LogController(context);
            var result = controller.Index();
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public void LogDetailsTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new LogController(context);
            var result = controller.Details(null);
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public void LokacioIndexTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new LokaciosController(context, userMgr);
            var result = controller.Index();
            Assert.True(result.IsCompletedSuccessfully);

        }
        [Fact]
        public void LokacioDetailsTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new LokaciosController(context, userMgr);
            var result = controller.Details(null);
            Assert.True(result.IsCompletedSuccessfully);

        }

        [Fact]
        public void RaktarIndexTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var controller = new RaktarsController(context);
            var result = controller.Index();
            Assert.True(result.IsCompletedSuccessfully);

        }


        [Fact]
        public void RaktarDetailsTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var controller = new RaktarsController(context);
            var result = controller.Details(null);
            Assert.True(result.IsCompletedSuccessfully);

        }

        [Fact]
        public void TermekTipusIndexTest()
        {

            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new TermekTipusController(context);
            var result = controller.Index(null);
            Assert.True(result.IsCompletedSuccessfully);

        }

        [Fact]
        public void TermekTipusDetailsTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<RaktarContext>()
                 .UseInMemoryDatabase("RaktarContext")
                 .Options;
            var context = new RaktarContext(options);
            var store = new Mock<IUserStore<Alkalmazott>>();
            var userMgr = new UserManager<Alkalmazott>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new TermekTipusController(context);

            //Act
            var result = controller.Details(null);

            //Assert
            Assert.True(result.IsCompletedSuccessfully);

        }


    }
}
