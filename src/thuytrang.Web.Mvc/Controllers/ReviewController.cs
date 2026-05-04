using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using thuytrang.Controllers;
using thuytrang.Reviews;

namespace thuytrang.Web.Controllers // Thêm namespace để tránh lỗi hệ thống
{
    public class ReviewController : thuytrangControllerBase
    {
        private readonly IReviewAppService _reviewAppService;

        public ReviewController(IReviewAppService reviewAppService)
        {
            _reviewAppService = reviewAppService;
        }

        public IActionResult Index() => View();

        // Sửa int thành long ở tham số truyền vào
        public async Task<ActionResult> EditModal(long reviewId)
        {
            // Sửa EntityDto<int> thành EntityDto<long>
            var review = await _reviewAppService.GetAsync(new EntityDto<long>(reviewId));
            return PartialView("_EditModal", review);
        }
    }
}
