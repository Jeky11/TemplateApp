using System.Data.Entity;

namespace TemplateApp.Data
{
    internal class TemplateAppContext : DbContext
    {
        public TemplateAppContext()
            : base("ConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new DbUserConfig());
        }
    }
}
