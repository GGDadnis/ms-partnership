using AutoMapper;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Review;

namespace ms_partnership.Profiles
{
    public class ReviewProfiles : Profile
    {
        public ReviewProfiles()
        {
            CreateMap<AddReviewDto, Review>();
            CreateMap<Review, ReadReviewDto>();
            CreateMap<UpdateReviewDto, Review>();
        }
    }
}