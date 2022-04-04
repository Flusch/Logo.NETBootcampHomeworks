using logo_odev5.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace logo_odev5.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get();
        T GetById(Expression<Func<T, bool>> filter);
        void Add(T entity);
    }
}
