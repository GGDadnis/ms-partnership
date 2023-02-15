using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Exceptions.InterfacesExceptions;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities.Dtos.Login;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _interfaces;
        private readonly ILoginExceptions _exceptions;

        public LoginController(ILogin interfaces, ILoginExceptions exceptions)
        {
            _interfaces = interfaces;
            _exceptions = exceptions;
        }

        public static IEnumerable<String> messageException(Result result)
        {
            return result.Reasons.Select(reason => reason.Message);
        }

        [HttpPost]
        public IActionResult CreateLogin([FromBody] AddLoginDto dto)
        {
            Result resultBlockCopycat, resultNeedToHaveUserOrCompany;

            resultNeedToHaveUserOrCompany = _exceptions.NeedToHaveUserOrCompany(dto.UserId, dto.CompanyId);
            if (resultNeedToHaveUserOrCompany.IsFailed)
            {
                return BadRequest(messageException(resultNeedToHaveUserOrCompany));
            }
            
            resultBlockCopycat = _exceptions.BlockCopycat(dto.Email);
            if (resultBlockCopycat.IsFailed)
            {
                return BadRequest(messageException(resultBlockCopycat));
            }

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
            Result resultBlockCopycatAtUpdate;

            resultBlockCopycatAtUpdate = _exceptions.BlockCopycatAtUpdate(id, dto.Email);
            if (resultBlockCopycatAtUpdate.IsFailed)
            {
                return BadRequest(messageException(resultBlockCopycatAtUpdate));
            }

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