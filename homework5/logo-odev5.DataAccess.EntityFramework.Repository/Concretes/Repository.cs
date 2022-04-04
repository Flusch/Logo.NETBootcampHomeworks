using logo_odev5.Domain.Entities;
using logo_odev5.DataAccess.EntityFramework.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace logo_odev5.DataAccess.EntityFramework.Repository.Concretes
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
            return unitOfWork.Context.Set<T>().AsQueryable();
        }
        public T GetById(Expression<Func<T, bool>> filter)
        {
            return unitOfWork.Context.Set<T>().SingleOrDefault(filter);
        }
    }
}
