using System;
using System.Linq;
using System.Web.Mvc;
using TemplateApp.Core.DI;
using TemplateApp.Data;
using TemplateApp.Data.Repo;
using TemplateApp.Web.Models.Home;

namespace TemplateApp.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            using (var uow = UnityManager.Instance.Resolve<IUnitOfWork>())
            {
                var users = uow.GetRepo<IDbUserRepo>().GetAll();
                var result = users.Select(x => new DbUserModel
                {
                    DbUserId = x.DbUserId,
                    Email = x.Email,
                    FullName = x.FullName,
                    HourlyRate = x.HourlyRate
                }).ToList();

                return View(result);
            }
        }

        public ActionResult Create()
        {
            using (var uow = UnityManager.Instance.Resolve<IUnitOfWork>())
            {
                var repo = uow.GetRepo<IDbUserRepo>();
                var count = repo.GetAll().Count() + 1;
                var str = "test" + count.ToString();

                repo.Add(str, String.Empty, str, null, str, count);
                uow.Commit();
            }

            return RedirectToAction("Index");
        }
	}
}