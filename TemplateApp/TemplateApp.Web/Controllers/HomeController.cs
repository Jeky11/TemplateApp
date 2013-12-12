using System.Linq;
using System.Web.Mvc;
using TemplateApp.Core.DI;
using TemplateApp.Data;
using TemplateApp.Data.Repo;

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
                var users = uow.GetRepo<IDbUserRepo>().GetAll().ToList();
                
            }

            return View();
        }

        public ActionResult Create()
        {
            using (var uow = UnityManager.Instance.Resolve<IUnitOfWork>())
            {
                uow.GetRepo<IDbUserRepo>().Add("test");
                uow.Commit();
            }

            return RedirectToAction("Index");
        }
	}
}