using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thuytrang.Reviews
{
    [Table("AppReviews")] // Đặt tên bảng rõ ràng trong Database
    public class Review : FullAuditedEntity<long> // Khóa chính kiểu long
    {
        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public bool IsActive { get; set; } = true;

        // Constructor mặc định
        public Review()
        {
            IsActive = true;
        }
    }
}
