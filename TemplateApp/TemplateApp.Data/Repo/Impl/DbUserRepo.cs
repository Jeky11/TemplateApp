using System;
using System.Data.Entity;
using System.Linq;
using TemplateApp.Data.Entities;

namespace TemplateApp.Data.Repo.Impl
{
    internal class DbUserRepo : RepoBase<DbUser, TemplateAppContext>, IDbUserRepo
    {
        public DbUserRepo(UnitOfWork<TemplateAppContext> unitOfWork)
            : base(unitOfWork)
        {
        }

        public DbUser GetByLogin(String login)
        {
            return DbSet.FirstOrDefault(x => x.Login == login);
        }

        public DbUser GetByLoginAndPass(String login, String password)
        {
            return DbSet.FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public Boolean IsExist(String login)
        {
            return this.IsExist(x => x.Login == login);
        }

        public DbUser Add(String login)
        {
            return Add(login, null, login, null, null, 0);
        }

        public DbUser Add(String login, String password, String firstName, String lastName, String email, Int32 hourlyRate)
        {
            return Add(new DbUser
            {
                Login = login,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                FullName = firstName + " " + lastName,
                Email = email,
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = DateTimeOffset.Now,
            });
        }

        public DbUser AddPassword(Int64 dbUserId, String password)
        {
            var entity = Get(dbUserId);
            entity.Password = password;
            entity.UpdatedDate = DateTimeOffset.Now;
            return entity;
        }

        public DbUser ChangePassword(Int64 dbUserId, String oldPassword, String password)
        {
            var entity = Get(dbUserId);
            if (entity.Password == oldPassword)
            {
                entity.Password = password;
                entity.UpdatedDate = DateTimeOffset.Now;
            }
            return entity;
        }
    }
}
