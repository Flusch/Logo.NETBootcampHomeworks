using logo_odev4.DataAccess.EntityFramework.Repository.Abstracts;
using logo_odev4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace logo_odev4.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IQueryable<T> Get()
        {
            return unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        }
        public void Add(T entity)
        {
            unitOfWork.Context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            T exist = unitOfWork.Context.Set<T>().Find(entity.Id);
            if (exist != null)
            {
                exist.IsDeleted = true;
                unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
