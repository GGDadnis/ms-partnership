using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities.Dtos.Promo;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PromoController : ControllerBase
    {
        private readonly IPromo _interfaces;

        public PromoController(IPromo interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult CreatePromo([FromBody] AddPromoDto? dto)
        {
            var promo = _interfaces.Add(dto);
            if (promo != null)
            {
                return Ok(promo);
            }
            return BadRequest("Fail to create promo");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var promos = _interfaces.SearchAll();
            if (promos != null)
            {
                return Ok(promos);
            }
            return BadRequest("Fail to find promos");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);
            if (idResult.IsFailed)
            {
                return BadRequest("Invalid promo id");
            }
            var promo = _interfaces.SearchById(id);
            if (promo != null)
            {
                return Ok(promo);
            }
            return NotFound("Fail to find promo");
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePromo(Guid id, [FromBody] UpdatePromoDto dto)
        {
            ReadPromoDto promo = _interfaces.Update(id, dto);
            if (promo != null)
            {
                return Ok(promo);
            }
            return BadRequest("Fail to update promo");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePromo(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);

            if (idResult.IsFailed)
            {
                return BadRequest("Invalid promo id");
            }

            var promo = _interfaces.Remove(id);
            if (promo != true)
            {
                return BadRequest("Fail to delete promo");
            }

            return Ok("Promo deleted with sucess");
        }
    }
}