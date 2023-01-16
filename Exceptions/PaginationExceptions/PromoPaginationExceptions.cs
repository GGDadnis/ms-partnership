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
                return Result.Fail("Página não é válida");
            }

            return Result.Ok();
        }

        public Result ValidateSize(int id)
        {
            if (id <= 0)
            {
                return Result.Fail("Tamanho não é válido");
            }

            return Result.Ok();
        }
    }
}