using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateApp.Core.DI;
using TemplateApp.Data.Entities;

namespace TemplateApp.Data.Test
{
    [TestClass]
    public abstract class UnitTestBase
    {
        protected UnitTestBase(Boolean recreateDbForEachTest = true)
        {
            UnityManager.Instance.RegisterAllSetups();
            RecreateDbForEachTest = recreateDbForEachTest;
            if (!RecreateDbForEachTest)
            {
                ReCreateDataBase();
            }
        }

        public Boolean RecreateDbForEachTest { get; private set; }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test 
        [TestInitialize]
        public void MyTestInitialize()
        {
            if (RecreateDbForEachTest)
            {
                ReCreateDataBase();
            }
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
        }


        private void ReCreateDataBase()
        {
            using (var uow = UnityManager.Instance.Resolve<IUnitOfWork>())
            {
                uow.DbContext.Database.Delete();
                uow.DbContext.Database.Initialize(true);

                FillDataBase(uow.DbContext);

                uow.Commit();
            }
        }

        private void FillDataBase(DbContext dbContext)
        {
            dbContext.Set<DbUser>().AddOrUpdate(
                p => p.Login,
                new DbUser { Login = "test", FirstName = "test", HourlyRate = 10, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new DbUser { Login = "test2", FirstName = "test2", HourlyRate = 10, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new DbUser { Login = "test3", FirstName = "test3", HourlyRate = 10, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
        }
    }
}
