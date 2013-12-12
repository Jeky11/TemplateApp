using System;
using Microsoft.Practices.Unity;

namespace TemplateApp.Core.DI
{
    public class UnityManager : DiManagerBase<IUnitySetup, IUnityContainer>
    {
        #region singleton

        public static UnityManager Instance
        {
            get
            {
                if (_instance == null) _instance = new UnityManager();
                return _instance;
            }
        }

        private static UnityManager _instance = null;

        #endregion singleton

        public UnityManager()
            : base(new UnityContainer())
        {
        }

        public override T Resolve<T>()
        {
            return DiContainer.Resolve<T>();
        }

        public override T Resolve<T>(String paramName, Object paramValue)
        {
            return DiContainer.Resolve<T>(new ParameterOverride(paramName, paramValue));
        }

        public virtual T Resolve<T>(params ResolverOverride[] overrides)
        {
            return DiContainer.Resolve<T>(overrides);
        }

        public virtual object Resolve(Type t, params ResolverOverride[] overrides)
        {
            return DiContainer.Resolve(t, overrides);
        }

        public virtual T Resolve<T>(String name, params ResolverOverride[] overrides)
        {
            return DiContainer.Resolve<T>(name, overrides);
        }

        protected override void RegisterTypes(IUnitySetup diSetup, IUnityContainer diContainer)
        {
            diSetup.RegisterTypes(diContainer);
        }
    }
}
