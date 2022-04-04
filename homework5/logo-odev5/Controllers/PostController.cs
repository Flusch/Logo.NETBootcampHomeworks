using logo_odev5.Models;
using logo_odev5.Domain.Entities;
using logo_odev5.Business.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace logo_odev5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Log()
        {
            return NoContent();
        }

        [Route("GetAllCompanies")]
        [HttpGet]
        public IActionResult Get()
        {
            var companies = companyService.GetAllCompany().Select(x => new CompanyDto
            {
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                Description = x.Description,
                Location = x.Location,
                Phone = x.Phone
            });
            return Ok(new CompanyResponse { Data = companies, Success = true });
        }

        [Route("GetCompanyById/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var company = companyService.GetCompanyById(x => x.Id == id);
            if (company == null)
            {
                return NotFound(new CompanyResponse { Success = false, Error = "Company not found" });
            }
            return Ok(new CompanyResponse
            {
                Data = new CompanyDto
                {
                    Name = company.Name,
                    Address = company.Address,
                    City = company.City,
                    Country = company.Country,
                    Description = company.Description,
                    Location = company.Location,
                    Phone = company.Phone
                },
                Success = true
            });
        }

        [Route("AddCompany")]
        [HttpPost]
        public IActionResult Add([FromBody] CompanyDto model)
        {
            companyService.AddCompany(new Company
            {
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Location = model.Location,
                Phone = model.Phone,
                Description = model.Description,
                CreatedBy = "Yavuz Selim",
                CreatedAt = System.DateTime.Now,
                IsDeleted = false
            });
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }

        [Route("UpdateCompanyById/{id}")]
        [HttpPost]
        public IActionResult Update([FromBody] CompanyDto model, int id)
        {
            companyService.UpdateCompanyById(new Company
            {
                Id = id,
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Location = model.Location,
                Phone = model.Phone,
                Description = model.Description,
                LastUpdatedBy = "Yavuz Selim"
            });
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }

        [Route("DeleteCompanyById/{id}")]
        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            companyService.DeleteCompanyById(new Company
            {
                Id = id,
                LastUpdatedBy = "Yavuz Selim"
            });
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }
    }
}
