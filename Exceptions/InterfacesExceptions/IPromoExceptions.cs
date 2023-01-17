using FluentResults;

namespace ms_partnership.Exceptions.InterfacesExceptions
{
    public interface IPromoExceptions
    {
        Result BlockStartAfterEndDate(DateTime start, DateTime end);
    }
}