using logo_odev4.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace logo_odev4.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get();
        public T GetById(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
