using logo_odev4.Business.DTOs;
using logo_odev4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace logo_odev4.Business.Abstracts
{
    public interface ICompanyService
    {
        Company GetCompanyById(Expression<Func<Company, bool>> filter);
        List<Company> GetAllCompany();
        void AddCompany(Company company);
        void UpdateCompanyById(Company company);
        void DeleteCompanyById(Company company);
    }
}
