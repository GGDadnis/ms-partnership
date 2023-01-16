using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Interfaces;
using ms_partnership.Interfaces.PaginationInterfaces;
using ms_partnership.Models.Entities.Dtos.Promo;
using ms_partnership.Models.Pagination;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PromoController : ControllerBase
    {
        private readonly IPromo _interfaces;
        private readonly IPromoPaginationExceptions _pagingexceptions;

        public PromoController(IPromo interfaces, IPromoPaginationExceptions pagingexceptions)
        {
            _interfaces = interfaces;
            _pagingexceptions = pagingexceptions;
        }

        public static IEnumerable<String> messageException(Result result)
        {
            return result.Reasons.Select(reason => reason.Message);
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

        [HttpGet("PagingByPeriod/{period:datetime}/page/{page:int}/itemsPage/{itemsPage:int}")]
        public IActionResult PromosByPeriod(DateTime period, int page = 1, int itemsPage = 9)
        {
            Result resultPage, resultItems;

            resultPage = _pagingexceptions.ValidatePage(itemsPage);

            if (resultPage.IsFailed)
            {
                return BadRequest(messageException(resultPage));
            }

            resultItems = _pagingexceptions.ValidateSize(itemsPage);

            if (resultItems.IsFailed)
            {
                return BadRequest(messageException(resultItems));
            }

            PromoPagination promos = _interfaces.promoPaginationPeriod(page, itemsPage, period);

            return Ok(promos);
        }

        [HttpGet("PagingByCompany/{companyId:Guid}/page/{page:int}/itemsPage/{itemsPage:int}")]
        public IActionResult PromosByCompany(Guid companyId, int page = 1, int itemsPage = 9)
        {
            Result resultPage, resultItems;

            resultPage = _pagingexceptions.ValidatePage(itemsPage);

            if (resultPage.IsFailed)
            {
                return BadRequest(messageException(resultPage));
            }

            resultItems = _pagingexceptions.ValidateSize(itemsPage);

            if (resultItems.IsFailed)
            {
                return BadRequest(messageException(resultItems));
            }

            PromoPagination promos = _interfaces.promoPaginationCompany(companyId, page, itemsPage);

            return Ok(promos);
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