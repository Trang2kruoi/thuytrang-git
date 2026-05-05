using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace thuytrang.Reviews
{
    public class Review : FullAuditedEntity<Guid>
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }     // Tiêu đề

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }   // Nội dung

        [Range(1, 5)]
        public int Rating { get; set; }       // Số sao (1-5)

        public bool IsActive { get; set; } = true; // ✅ default tránh lỗi null
    }
}