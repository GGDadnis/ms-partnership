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
        private readonly IAddress _interfaces;


        public AddressController(IAddress interfaceAddress)
        {
            _interfaces = interfaceAddress;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(AddAddressDto dto)
        {

            ReadAddressDto address = await _interfaces.AddAsync(dto);

            if (address != null)
            {
                return Ok(address);
            }

            return BadRequest("Fail to create address");
        }

        [HttpGet]
        public IActionResult getAllAddress()
        {
            var addresses = _interfaces.SearchAll();
            if (addresses != null)
            {
                return Ok(addresses);
            }
            return BadRequest("Fail to find users");
        }

        [HttpGet("{id}")]
        public IActionResult getAddressById(Guid id)
        {
            ReadAddressDto address = _interfaces.SearchById(id);

            if (address != null)
            {
                return Ok(address);
            }

            return BadRequest("Address not found");

        }

        [HttpPut("{id}")]
        public IActionResult updateAddress(Guid id, UpdateAddressDto updatedAddress)
        {
            ReadAddressDto address = _interfaces.Update(id, updatedAddress);

            if (address != null)
            {
                return Ok(address);
            }

            return BadRequest("Fail to update address");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteAddress(Guid id)
        {
            bool resultDelete = _interfaces.Remove(id);

            if (resultDelete)
            {
                return Ok("Address deleted!");
            }

            return BadRequest("Fail to delete address");
        }
    }
}