using System.Data.Entity.ModelConfiguration;
using TemplateApp.Data.Entities;

namespace TemplateApp.Data.Cofigs
{
    internal class DbUserConfig : EntityTypeConfiguration<DbUser>
    {
        public DbUserConfig()
        {
            ToTable("DbUser");
            HasKey(x => x.DbUserId);

            Property(x => x.Login).IsRequired().HasMaxLength(100);
            Property(x => x.Password).HasMaxLength(100);
            Property(x => x.Email).HasMaxLength(100);
            Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            Property(x => x.LastName).HasMaxLength(100);
            Property(x => x.FullName).HasMaxLength(200);
            Property(x => x.HourlyRate).IsRequired();
            Property(x => x.CreatedDate).IsRequired();
            Property(x => x.UpdatedDate).IsRequired();
        }
    }
}
