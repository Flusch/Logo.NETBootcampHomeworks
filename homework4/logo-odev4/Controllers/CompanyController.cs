using logo_odev4.Models;
using logo_odev4.Business.DTOs;
using logo_odev4.Domain.Entities;
using logo_odev4.Business.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using logo_odev4.Filters;

namespace logo_odev4.Controllers
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
        [Log]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Log()
        {
            return NoContent();
        }

        /// <summary>
        /// Tüm şirket bilgilerini getirir.
        /// </summary>
        /// <returns></returns>
        [Route("Companies")]
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

        /// <summary>
        /// Şirket ekleme işlemi yapar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Şirket güncelleme işlemi yapar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UpdateCompany")]
        [HttpPost]
        public IActionResult Update([FromBody] CompanyDto model)
        {
            companyService.UpdateCompany(new Company
            {
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Location = model.Location,
                Phone = model.Phone,
                Description = model.Description,
                CreatedBy = "Yavuz Selim",
                //CreatedAt = System.DateTime.Now,
                LastUpdatedBy = "Yavuz Selim",
                LastUpdatedAt = System.DateTime.Now,
                IsDeleted = false
            });
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }
        /*
        /// <summary>
        /// Şirket silme işlemi yapar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("DeleteCompany")]
        [HttpPost]
        public IActionResult Delete([FromBody] CompanyDto model)
        {
            companyService.DeleteCompany(new Company
            {
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Location = model.Location,
                Phone = model.Phone,
                Description = model.Description,
                LastUpdatedBy = "Yavuz Selim",
                LastUpdatedAt = System.DateTime.Now,
            });
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }*/

        [Route("DeleteCompany")]
        [HttpPost]
        public IActionResult Delete([FromQuery] int id)
        {
            companyService.DeleteCompany(new Company
            {
                Id = id,
                IsDeleted = true,
                LastUpdatedBy = "Yavuz Selim",
                LastUpdatedAt = System.DateTime.Now,
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
