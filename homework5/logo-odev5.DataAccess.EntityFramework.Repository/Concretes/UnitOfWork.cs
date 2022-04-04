using logo_odev5.DataAccess.EntityFramework.Repository.Abstracts;

namespace logo_odev5.DataAccess.EntityFramework.Repository.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext Context { get; }
        public UnitOfWork(AppDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
