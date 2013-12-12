using System;

namespace TemplateApp.Core.DI
{
    public interface IDiManager
    {
        T Resolve<T>();

        T Resolve<T>(String paramName, Object paramValue);

        void RegisterAllSetups();
    }
}
