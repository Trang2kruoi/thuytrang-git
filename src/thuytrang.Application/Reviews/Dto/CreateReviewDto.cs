using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace thuytrang.Reviews.Dto
{
    [AutoMapTo(typeof(Review))]
    public class CreateReviewDto
    {
        [Required(ErrorMessage = "Nội dung đánh giá không được để trống")]
        [StringLength(2000)]
        public string Content { get; set; }

        [Range(1, 5, ErrorMessage = "Số sao phải từ 1 đến 5")]
        public int Rating { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
