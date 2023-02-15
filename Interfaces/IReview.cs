using ms_partnership.Models.Entities.Dtos.Review;

namespace ms_partnership.Interfaces
{
    public interface IReview : IBaseGuid<AddReviewDto, ReadReviewDto>, IUpdate<UpdateReviewDto, ReadReviewDto>
    {
        IEnumerable<ReadReviewDto> SearchReviewByCompany(Guid id);
    }
}