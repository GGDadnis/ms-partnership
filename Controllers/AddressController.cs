using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities.Dtos.Address;
using ms_partnership.Service;

namespace ms_partnership.Controllers
{
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddress _interface;


        public AddressController(IAddress interfaceAddress)
        {
            _interface = interfaceAddress;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(AddAddressDto dto)
        {

            ReadAddressDto address = await _interface.AddAsync(dto);

            if (address != null)
            {
                return Ok(address);
            }

            return BadRequest("Fail to create address");
        }
    }
}