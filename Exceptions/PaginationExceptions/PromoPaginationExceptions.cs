using FluentResults;
using ms_partnership.Interfaces.PaginationInterfaces;

namespace ms_partnership.Exceptions.PaginationExceptions
{
    public class PromoPaginationExceptions : IPromoPaginationExceptions
    {
        public Result ValidatePage(int id)
        {
            if (id <= 0)
            {
                return Result.Fail("Page is not valid.");
            }

            return Result.Ok();
        }

        public Result ValidateSize(int id)
        {
            if (id <= 0)
            {
                return Result.Fail("Size is not valid.");
            }

            return Result.Ok();
        }
    }
}