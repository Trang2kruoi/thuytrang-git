using Abp.Application.Services;
using thuytrang.Reviews.Dto;

namespace thuytrang.Reviews
{
    // Kế thừa IAsyncCrudAppService sẽ tự động có các hàm: Get, GetAll, Create, Update, Delete
    public interface IReviewAppService : IAsyncCrudAppService<ReviewDto, int, PagedReviewResultRequestDto, CreateReviewDto, ReviewDto>
    {
    }
}