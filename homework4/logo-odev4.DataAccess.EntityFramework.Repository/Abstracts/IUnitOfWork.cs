using logo_odev4.DataAccess.EntityFramework;
using System;

namespace logo_odev4.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext Context { get; }
        void Commit();

    }
}
