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
            if (company != null)
            {
                return Ok(company);
            }
            return BadRequest("Fail to create company");
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
            if (company != null)
            {
                return Ok(company);
            }
            return BadRequest("Fail to update company");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);

            if (idResult.IsFailed)
            {
                return BadRequest("Invalid company id");
            }

            var company = _interfaces.Remove(id);
            if (company != true)
            {
                return BadRequest("Fail to delete company");
            }

            return Ok("Company deleted with sucess");
        }
        
    }
}