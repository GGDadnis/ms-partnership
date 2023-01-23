using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities.Dtos.User;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _interfaces;

        public UserController(IUser interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] AddUserDto? dto)
        {
            var user = _interfaces.Add(dto);
            if (user != null)
            {
                return Ok(user);
            }
            if (user.AvatarImg == "SEND_ERROR")
            {
                return BadRequest("Fail to send S3 image");
            }
            return BadRequest("Fail to create user");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _interfaces.SearchAll();
            if (users != null)
            {
                return Ok(users);
            }
            return BadRequest("Fail to find users");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);
            if (idResult.IsFailed)
            {
                return BadRequest("Invalid user id");
            }
            var user = _interfaces.SearchById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("Fail to find user");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserDto dto)
        {
            ReadUserDto user = _interfaces.Update(id, dto);
            if (user != null)
            {
                return Ok(user);
            }
            if (user.AvatarImg == "SEND_ERROR")
                return BadRequest("Fail to send S3 image");
            if (user.AvatarImg == "DELETE_ERROR")
                return BadRequest("Fail to delete S3 image");
            return BadRequest("Fail to update user");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);

            if (idResult.IsFailed)
            {
                return BadRequest("Invalid user id");
            }

            var user = _interfaces.Remove(id);
            if (user != true)
            {
                return BadRequest("Fail to delete user");
            }

            return Ok("User deleted with sucess");
        }
    }
}