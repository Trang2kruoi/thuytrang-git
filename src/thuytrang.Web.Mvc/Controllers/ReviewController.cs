using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using thuytrang.Controllers;
using thuytrang.Reviews;

namespace thuytrang.Web.Controllers
{
    public class ReviewController : thuytrangControllerBase
    {
        private readonly IReviewAppService _reviewAppService;

        public ReviewController(IReviewAppService reviewAppService)
        {
            _reviewAppService = reviewAppService;
        }

        public ActionResult Index() => View();

        // Bắt buộc dùng int để khớp với hệ thống
        public async Task<ActionResult> EditModal(int reviewId)
        {
            // Lấy dữ liệu review cũ theo Id để fill vào Modal
            var review = await _reviewAppService.GetAsync(new EntityDto<int>(reviewId));
            return PartialView("_EditModal", review);
        }
    }
}