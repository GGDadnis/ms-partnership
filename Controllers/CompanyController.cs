using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities.Dtos.Company;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _interfaces;

        public CompanyController(ICompany interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] AddCompanyDto? dto)
        {
            var company = _interfaces.Add(dto);
            if (company == null)
            {
                return BadRequest("Fail to create company");
            }
            if (company.Category == null)
            {
                return NotFound("Fail to find category");
            }
            if (company.LogoImg == "SEND_ERROR")
                return BadRequest("Fail to send S3 image");
            if (company.LogoImg == "CONVERTION_ERROR")
                return BadRequest("S3 Image Unsupported Media Type");
            return Ok(company);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _interfaces.SearchAll();
            if (companies != null)
            {
                return Ok(companies);
            }
            return BadRequest("Fail to find companies");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);
            if (idResult.IsFailed)
            {
                return BadRequest("Invalid company id");
            }
            var company = _interfaces.SearchById(id);
            if (company != null)
            {
                return Ok(company);
            }
            return NotFound("Fail to find company");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(Guid id, [FromBody] UpdateCompanyDto dto)
        {
            ReadCompanyDto company= _interfaces.Update(id, dto);
            if (company == null)
            {
                return BadRequest("Fail to update company");
            }
            if (company.LogoImg == "SEND_ERROR")
                return BadRequest("Fail to send S3 image");
            if (company.LogoImg == "CONVERTION_ERROR")
                return BadRequest("S3 Image Unsupported Media Type");
            if (company.LogoImg == "DELETE_ERROR")
                return BadRequest("Fail to delete S3 image");
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);

            if (idResult.IsFailed)
            {
                return BadRequest("Invalid company id");
            }

            var company = _interfaces.LogicalRemove(id);
            if (company != null)
            {
                if (company.LogoImg == "DELETE_ERROR")
                    return BadRequest("Fail to delete S3 image");
                return Ok("Company deleted with sucess");
            }
            return BadRequest("Fail to delete company");
        }
    }
}