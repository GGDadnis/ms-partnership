using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities.Dtos.Login;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _interfaces;

        public LoginController(ILogin interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLogin(AddLoginDto dto)
        {
            var login = _interfaces.Add(dto);
            if (login != null)
            {
                return Ok(login);
            }
            return BadRequest("Fail to create login");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var login = _interfaces.SearchAll();
            if (login != null)
            {
                return Ok(login);
            }
            return BadRequest("Fail to find logins");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);
            if (idResult.IsFailed)
            {
                return BadRequest("Invalid login id");
            }

            var login = _interfaces.SearchById(id);
            if (login != null)
            {
                return Ok(login);
            }
            return NotFound("Fail to find login");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLogin(Guid id, [FromBody] UpdateLoginDto dto)
        {
            ReadLoginDto login = _interfaces.Update(id, dto);
            if (login != null)
            {
                return Ok(login);
            }
            return BadRequest("Fail to update login");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLogin(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);

            if (idResult.IsFailed)
            {
                return BadRequest("Invalid login id");
            }

            var login = _interfaces.Remove(id);
            if (login != true)
            {
                return BadRequest("Fail to delete login");
            }
            return Ok("Login deleted with sucess");
        }
    }
}