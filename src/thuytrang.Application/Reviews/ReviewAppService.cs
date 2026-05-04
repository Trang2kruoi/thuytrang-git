using Abp.Application.Services;
using Abp.Domain.Repositories;
using thuytrang.Reviews.Dto;

namespace thuytrang.Reviews
{
    // Đổi tất cả int thành long để khớp với Entity Review (Id kiểu long)
    public class ReviewAppService : AsyncCrudAppService<Review, ReviewDto, long, PagedReviewResultRequestDto, CreateReviewDto, ReviewDto>, IReviewAppService
    {
        public ReviewAppService(IRepository<Review, long> repository)
            : base(repository)
        {
        }
    }
}
