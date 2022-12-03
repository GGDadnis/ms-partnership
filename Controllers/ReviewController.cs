using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities.Dtos.Review;

namespace ms_partnership.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReview _interfaces;

        public ReviewController(IReview interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult CreateReview([FromBody] AddReviewDto? dto)
        {
            var review = _interfaces.Add(dto);
            if (review != null)
            {
                return Ok(review);
            }
            return BadRequest("Fail to create review");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = _interfaces.SearchAll();
            if (reviews != null)
            {
                return Ok(reviews);
            }
            return BadRequest("Fail to find reviews");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);
            if (idResult.IsFailed)
            {
                return BadRequest("Invalid review id");
            }
            var company = _interfaces.SearchById(id);
            if (company != null)
            {
                return Ok(company);
            }
            return NotFound("Fail to find review");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReview(Guid id, [FromBody] UpdateReviewDto dto)
        {
            ReadReviewDto review = _interfaces.Update(id, dto);
            if (review != null)
            {
                return Ok(review);
            }
            return BadRequest("Fail to update review");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(Guid id)
        {
            Result idResult = _interfaces.IdValidate(id);

            if (idResult.IsFailed)
            {
                return BadRequest("Invalid review id");
            }

            var review = _interfaces.Remove(id);
            if (review != true)
            {
                return BadRequest("Fail to delete review");
            }

            return Ok("Review deleted with sucess");
        }
    }
}