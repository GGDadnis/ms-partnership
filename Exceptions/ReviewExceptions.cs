using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Exceptions.InterfacesExceptions;

namespace ms_partnership.Exceptions
{
    public class ReviewExceptions : IReviewExceptions
    {
        private readonly AppDbContext? _context;
        private readonly IMapper? _mapper;

        public ReviewExceptions(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result TheGoodTheBadAndTheGrade(Boolean good, Boolean bad)
        {
            if(good == bad)
            {
                return Result.Fail("Good and bad grades shouldn't be equals");
            }

            return Result.Ok();
        }
    }
}