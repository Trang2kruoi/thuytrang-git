using Abp.Application.Services;
using Abp.Domain.Repositories;
using thuytrang.Reviews.Dto;

namespace thuytrang.Reviews
{
    public class ReviewAppService : AsyncCrudAppService<Review, ReviewDto, int, PagedReviewResultRequestDto, CreateReviewDto, ReviewDto>, IReviewAppService
    {
        public ReviewAppService(IRepository<Review, int> repository)
            : base(repository)
        {
        }
    }
}