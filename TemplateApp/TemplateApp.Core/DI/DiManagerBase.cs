using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TemplateApp.Core.DI
{
    public abstract class DiManagerBase<TDiSetup, TDiContainer> : IDiManager
    {
        protected DiManagerBase(TDiContainer diContainer)
        {
            DiContainer = diContainer;
        }

        public TDiContainer DiContainer { get; private set; }

        public virtual void RegisterAllSetups()
        {
            var allTypes = GetAllTypes(Assembly.GetCallingAssembly());
            RegisterAllSetups(allTypes);
        }

        public abstract T Resolve<T>();

        public abstract T Resolve<T>(String paramName, Object paramValue);

        public IEnumerable<Type> GetAllTypes(Assembly callingAssembly)
        {
            var allTypes = new List<Type>();
            var names = callingAssembly.GetReferencedAssemblies().ToList();
            names.Add(Assembly.GetCallingAssembly().GetName());
            foreach (var item in names)
            {
                try
                {
                    var assembly = Assembly.Load(item.FullName);
                    var types = assembly.GetTypes();
                    allTypes.AddRange(types);
                }
                catch (Exception)
                {
                }
            }
            return allTypes;
        }

        public void RegisterAllSetups(IEnumerable<Type> allTypes)
        {
            var baseType = typeof(TDiSetup);
            var setupTypes = allTypes.Where(baseType.IsAssignableFrom).Where(t => t != baseType);
            foreach (var item in setupTypes)
            {
                var diSetup = (TDiSetup)Activator.CreateInstance(item);
                RegisterTypes(diSetup, DiContainer);
            }
        }

        protected abstract void RegisterTypes(TDiSetup diSetup, TDiContainer diContainer);
    }
}
