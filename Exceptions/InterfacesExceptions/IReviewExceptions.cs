using FluentResults;

namespace ms_partnership.Exceptions.InterfacesExceptions
{
    public interface IReviewExceptions
    {
        Result TheGoodTheBadAndTheGrade(Boolean good, Boolean bad);
    }
}