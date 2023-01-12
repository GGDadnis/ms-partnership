using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ms_partnership.Controllers.Security
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string GetAnonymous() => "Anonymous";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string GetAuthenticated() => "Authenticated";

        [HttpGet]
        [Route("user")]
        [Authorize]
        //[Authorize(Roles = UserRoles.User)]
        public string GetUser() => "User";

        [HttpGet]
        [Route("admin")]
        [Authorize]
        //[Authorize(Roles = UserRoles.Admin)]
        public string GetAdmin() => "Admin";

        [HttpGet]
        [Route("company")]
        [Authorize]
        //[Authorize(Roles = UserRoles.Company)]
        public string GetCompany() => "Company";

    }
}