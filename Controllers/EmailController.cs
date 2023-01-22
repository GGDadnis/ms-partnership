using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ms_partnership.Models.Entities;
using ms_partnership.Service.EmailService;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _mailService;

        public EmailController(IEmailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult sendMail(Email request)
        {
            _mailService.sendMail(request);

            return Ok("Email send with success");
        }


    }
}