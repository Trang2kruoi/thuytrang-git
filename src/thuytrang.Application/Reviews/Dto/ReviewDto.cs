using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace thuytrang.Reviews.Dto
{
    [AutoMapFrom(typeof(Review))]
    public class ReviewDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
    }
}