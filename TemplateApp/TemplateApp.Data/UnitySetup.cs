using System.Data.Entity;
using Microsoft.Practices.Unity;
using TemplateApp.Core.DI;
using TemplateApp.Data.Migrations;
using TemplateApp.Data.Repo;
using TemplateApp.Data.Repo.Impl;

namespace TemplateApp.Data
{
    public class UnitySetup : IUnitySetup
    {
        public void RegisterTypes(IUnityContainer container)
        {
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork<TemplateAppContext>>();

            //repos
            container.RegisterType<IDbUserRepo, DbUserRepo>();


            //update database when start
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TemplateAppContext, Configuration>());
        }
    }
}
