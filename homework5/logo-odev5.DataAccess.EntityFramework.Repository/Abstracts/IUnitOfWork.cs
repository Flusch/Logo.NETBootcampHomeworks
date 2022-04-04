using System;

namespace logo_odev5.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext Context { get; }
        void Commit();

    }
}
