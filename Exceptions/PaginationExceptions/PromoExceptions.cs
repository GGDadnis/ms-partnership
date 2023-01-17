using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Exceptions.InterfacesExceptions;

namespace ms_partnership.Exceptions.PaginationExceptions
{
    public class PromoExceptions : IPromoExceptions
    {
        private readonly AppDbContext? _context;
        private readonly IMapper? _mapper;

        public PromoExceptions(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result BlockStartAfterEndDate(DateTime start, DateTime end)
        {
            start += new TimeSpan(2, -1, 0);

            if (start >= end)
            {
                return Result.Fail("End of promo should have three or more hours after Start");
            }

            return Result.Ok();
        }
    }
}