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

        public Result BlockStartAfterEndDate(DateTime? start, DateTime? end)
        {
            if (start == null && end == null)
            {
                return Result.Ok();
            }

            start += new TimeSpan(1, -1, 0);
            if (start >= end)
            {
                return Result.Fail("Promo should have at least 1 hour of valid time");
            }

            return Result.Ok();
        }

        public Result BlockEndBeforeCreated(DateTime? end)
        {
            var Created = DateTime.UtcNow + new TimeSpan(1, -1, 0);
            if (end == null)
            {
                return Result.Ok();
            }

            if (Created >= end)
            {
                return Result.Fail("Promo should have at least 1 hour of valid time");
            }

            return Result.Ok();
        }
    }
}