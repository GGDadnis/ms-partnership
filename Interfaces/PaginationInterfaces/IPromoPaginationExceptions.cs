using FluentResults;

namespace ms_partnership.Interfaces.PaginationInterfaces
{
    public interface IPromoPaginationExceptions
    {
         Result ValidatePage(int id);

        Result ValidateSize(int id);
    }
}