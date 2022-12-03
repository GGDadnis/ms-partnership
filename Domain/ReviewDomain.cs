using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Review;

namespace ms_partnership.Domain
{
    public class ReviewDomain : IReview
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReviewDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadReviewDto Add(AddReviewDto dto)
        {
            Review review = _mapper.Map<Review>(dto);
            _context.Reviews.Add(review);
            _context.SaveChanges();
            ReadReviewDto reviewDto = _mapper.Map<ReadReviewDto>(review);
            return reviewDto;
        }

        public Result IdValidate(Guid id)
        {
            if (id == null)
            {
                return Result.Fail("");
            }
            return Result.Ok();
        }

        public bool Remove(Guid id)
        {
            Review review = _context.Reviews.FirstOrDefault(review => review.Id == id);
            if (review != null)
            {
                _context.Remove(review);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ReadReviewDto> SearchAll()
        {
            var lista = _context.Reviews.ToList();
            IEnumerable<ReadReviewDto> readReviewsDtos = _mapper.Map<List<ReadReviewDto>>(lista);
            return readReviewsDtos;
        }

        public ReadReviewDto SearchById(Guid id)
        {
            Review review = _context.Reviews.FirstOrDefault(review => review.Id == id);
            ReadReviewDto reviewDto = _mapper.Map<ReadReviewDto>(review);
            return reviewDto;
        }

        public ReadReviewDto Update(Guid id, UpdateReviewDto dto)
        {
            Review review = _context.Reviews.FirstOrDefault(review => review.Id == id);
            if(review != null)
            {
                _mapper.Map(dto, review);
                ReadReviewDto reviewDto = _mapper.Map<ReadReviewDto>(review);
                _context.SaveChanges();
                return reviewDto;
            }
            return null;
        }
    }
}