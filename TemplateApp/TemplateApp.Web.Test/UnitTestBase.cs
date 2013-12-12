using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using TemplateApp.Core.DI;
using TemplateApp.Data;
using Moq;

namespace TemplateApp.Web.Test
{
    public class UnitTestBase<TController> where TController : ControllerBase, new()
    {
        protected readonly Mock<IUnitOfWork> _mockIUnitOfWork = new Mock<IUnitOfWork>();

        public UnitTestBase()
        {
            UnityManager.Instance.DiContainer.RegisterInstance(_mockIUnitOfWork.Object);
        }

        public TController GetController()
        {
            var controller = new TController();
            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }
    }
}
