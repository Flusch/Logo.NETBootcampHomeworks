using logo_odev4.Business.DTOs;
using logo_odev4.Domain.Entities;
using System.Collections.Generic;

namespace logo_odev4.Business.Abstracts
{
    public interface ICompanyService
    {
        List<Company> GetAllCompany();
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
