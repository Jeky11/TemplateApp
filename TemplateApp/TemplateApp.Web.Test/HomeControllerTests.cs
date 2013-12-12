using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TemplateApp.Data.Entities;
using TemplateApp.Data.Repo;
using TemplateApp.Web.Controllers;
using TemplateApp.Web.Models.Home;

namespace TemplateApp.Web.Test
{
    [TestClass]
    public class HomeControllerTests : UnitTestBase<HomeController>
    {
        private readonly Mock<IDbUserRepo> _mockIDbUserRepo = new Mock<IDbUserRepo>();

        [TestInitialize]
        public void Init()
        {
            _mockIUnitOfWork.Setup(x => x.GetRepo<IDbUserRepo>()).Returns(_mockIDbUserRepo.Object);
        }

        [TestMethod]
        public void Index_Get()
        {
            var mockList = new List<DbUser>()
            {
                new DbUser {DbUserId = 1, Login = "test", FirstName = "test", Email = "test"},
                new DbUser {DbUserId = 2, Login = "test2", FirstName = "test2", Email = "test2"}
            };
            _mockIDbUserRepo.Setup(foo => foo.GetAll()).Returns(mockList.AsQueryable());

            var controller = GetController();
            var result = (ViewResult)controller.Index();
            
            Assert.AreEqual("", result.ViewName, "View is not correct");
            var model = result.Model as IEnumerable<DbUserModel>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count());
            Assert.AreEqual("test", model.First().Email);
            Assert.AreEqual(2, model.Last().DbUserId);
        }
    }
}
