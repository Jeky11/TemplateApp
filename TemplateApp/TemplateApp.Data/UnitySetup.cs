using System.Data.Entity;
using Microsoft.Practices.Unity;
using TemplateApp.Core.DI;
using TemplateApp.Data.Migrations;

namespace TemplateApp.Data
{
    public class UnitySetup : IUnitySetup
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork<TemplateAppContext>>();

            //container.RegisterType<IDbUserRepo, DbUserRepo>();


            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TemplateAppContext, Configuration>());
        }
    }
}
