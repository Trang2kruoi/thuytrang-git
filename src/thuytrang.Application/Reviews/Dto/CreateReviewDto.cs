using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace thuytrang.Reviews.Dto
{
    [AutoMapTo(typeof(Review))]
    public class CreateReviewDto
    {
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(2000)]
        public string Content { get; set; }

        // Ràng buộc số sao chỉ được phép từ 1 đến 5
        [Range(1, 5, ErrorMessage = "Số sao phải từ 1 đến 5")]
        public int Rating { get; set; }

        // Đặt mặc định là true (Hoạt động) khi tạo mới
        public bool IsActive { get; set; } = true;
    }
}