using Abp.Application.Services;
using Abp.Application.Services.Dto;
using thuytrang.Reviews.Dto;

namespace thuytrang.Reviews
{
    // Đổi int thành long ở tham số thứ 2
    public interface IReviewAppService : IAsyncCrudAppService<ReviewDto, long, PagedReviewResultRequestDto, CreateReviewDto, ReviewDto>
    {
        // Bạn có thể thêm các phương thức đặc biệt ở đây nếu cần, 
        // ví dụ: Task DuyetReview(long id);
    }
}
