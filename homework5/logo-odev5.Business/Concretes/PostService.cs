using logo_odev5.DataAccess.EntityFramework.Repository.Abstracts;
using logo_odev5.Domain.Entities;
using logo_odev5.Business.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace logo_odev5.Business.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public List<Company> GetAllCompany()
        {
            return repository.Get().ToList();
        }
        public Company GetCompanyById(Expression<Func<Company, bool>> filter)
        {
            return repository.GetById(filter);
        }
        public void AddCompany(Company company)
        {
            repository.Add(company);
            unitOfWork.Commit();
        }
        public void UpdateCompanyById(Company company)
        {
            repository.Update(company);
            unitOfWork.Commit();
        }
        public void DeleteCompanyById(Company company)
        {
            repository.Delete(company);
            unitOfWork.Commit();
        }
    }
}
