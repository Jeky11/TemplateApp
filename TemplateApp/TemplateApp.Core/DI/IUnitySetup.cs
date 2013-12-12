using Microsoft.Practices.Unity;

namespace TemplateApp.Core.DI
{
    public interface IUnitySetup
    {
        void RegisterTypes(IUnityContainer container);
    }
}
