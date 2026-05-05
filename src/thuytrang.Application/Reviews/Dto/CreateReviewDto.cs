using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace thuytrang.Reviews.Dto
{
    [AutoMapTo(typeof(Review))]
    public class CreateReviewDto
    {
        public Guid? Id { get; set; } // ✅ Tự quản lý Id (an toàn hơn)

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public bool IsActive { get; set; } = true; // ✅ default tránh null
    }
}