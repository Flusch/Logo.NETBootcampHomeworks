using logo_odev4.Business.Abstracts;
using logo_odev4.DataAccess.EntityFramework.Repository.Abstracts;
using logo_odev4.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace logo_odev4.Business.Concretes
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

        public void AddCompany(Company company)
        {
            repository.Add(company);
            unitOfWork.Commit();
        }

        public List<Company> GetAllCompany()
        {
            return repository.Get().ToList();
        }

        public void DeleteCompany(Company company)
        {
            repository.Delete(company);
            unitOfWork.Commit();
        }

        public void UpdateCompany(Company company)
        {
            repository.Update(company);
            unitOfWork.Commit();
        }
    }
}
