using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateApp.Core.DI;
using TemplateApp.Data.Repo;

namespace TemplateApp.Data.Test
{
    [TestClass]
    public class DbUserRepoTests : UnitTestBase
    {
        [TestMethod]
        public void GetAllTest()
        {
            using (var uow = UnityManager.Instance.Resolve<IUnitOfWork>())
            {
                var users = uow.GetRepo<IDbUserRepo>().GetAll().ToList();
                Assert.AreEqual(3, users.Count, "Count of users is not correct");
            }
        }

        [TestMethod]
        public void AddTest()
        {
            using (var uow = UnityManager.Instance.Resolve<IUnitOfWork>())
            {
                var repo = uow.GetRepo<IDbUserRepo>();
                repo.Add("addtest");
                uow.Commit();

                var users = uow.GetRepo<IDbUserRepo>().GetAll().ToList();
                Assert.AreEqual(4, users.Count, "Count of users is not correct");
                Assert.AreEqual("addtest", users.Last().Login, "login of user in not correct");
            }
        }
    }
}
