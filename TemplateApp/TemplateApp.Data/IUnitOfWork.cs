using System;
using System.Data.Entity;

namespace TemplateApp.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }

        Int32 Commit();

        TRepo GetRepo<TRepo>();
    }
}
