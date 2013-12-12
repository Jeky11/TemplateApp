using System;
using TemplateApp.Data.Entities;

namespace TemplateApp.Data.Repo
{
    public interface IDbUserRepo : IRepoBase<DbUser>
    {
        DbUser GetByLogin(String login);

        DbUser GetByLoginAndPass(String login, String password);

        Boolean IsExist(String login);

        DbUser Add(String login);

        DbUser Add(String login, String password, String firstName, String lastName, String email, Int32 hourlyRate);

        DbUser AddPassword(Int64 dbUserId, String password);

        DbUser ChangePassword(Int64 dbUserId, String oldPassword, String password);
    }
}
