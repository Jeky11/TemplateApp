using System;

namespace TemplateApp.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Int32 Commit();

        TRepo GetRepo<TRepo>();
    }
}
