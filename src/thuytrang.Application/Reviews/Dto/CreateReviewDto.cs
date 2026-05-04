using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace thuytrang.Reviews.Dto
{
    [AutoMapTo(typeof(Review))]
    public class CreateReviewDto
    {
        // Bổ sung Title kèm theo Validation
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(255, ErrorMessage = "Tiêu đề không được vượt quá 255 ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Nội dung đánh giá không được để trống")]
        [StringLength(2000, ErrorMessage = "Nội dung không được vượt quá 2000 ký tự")]
        public string Content { get; set; }

        [Range(1, 5, ErrorMessage = "Số sao phải từ 1 đến 5")]
        public int Rating { get; set; }

        public bool IsActive { get; set; } = true;
    }
}