using AutoMapper;
using thuytrang.Reviews.Dto;

namespace thuytrang.Reviews
{
    public class ReviewMapProfile : Profile
    {
        public ReviewMapProfile()
        {
            CreateMap<Review, ReviewDto>();
            CreateMap<CreateReviewDto, Review>();
        }
    }
}
