using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace thuytrang.Reviews.Dto
{
    [AutoMapFrom(typeof(Review))]
    // Đổi int thành long ở đây để khớp với Entity Review
    public class ReviewDto : EntityDto<long>
    {
        public string Content { get; set; }

        public int Rating { get; set; }

        public bool IsActive { get; set; }

        // Bạn có thể thêm trường này để hiện ngày đánh giá trên trang web
        public DateTime CreationTime { get; set; }
    }
}
