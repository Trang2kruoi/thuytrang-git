using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult> EditModal(Guid reviewId)
        {
            // Sửa EntityDto<int> thành EntityDto<Guid>
            var review = await _reviewAppService.GetAsync(new EntityDto<Guid>(reviewId));
            return PartialView("_EditModal", review);
        }
    }
}