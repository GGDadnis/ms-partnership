using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Auth;

namespace ms_partnership.Controllers.Security
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("test-anonymous")]
        [AllowAnonymous]
        public string GetAnonymous() => "Anonymous";

        [HttpGet]
        [Route("test-authenticated")]
        [Authorize]
        public string GetAuthenticated() => "Authenticated";

        [HttpGet]
        [Route("test-user")]
        [Authorize(Roles = UserRoles.User)]
        public string GetUser() => "User";

        [HttpGet]
        [Route("test-admin")]
        [Authorize(Roles = UserRoles.Admin)]
        public string GetAdmin() => "Admin";

        [HttpGet]
        [Route("test-company")]
        [Authorize(Roles = UserRoles.Company)]
        public string GetCompany() => "Company";

    }
}