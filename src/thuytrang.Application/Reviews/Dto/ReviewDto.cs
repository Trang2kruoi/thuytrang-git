using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace thuytrang.Reviews.Dto
{
    [AutoMap(typeof(Review))]
    public class ReviewDto : EntityDto<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        // Bổ sung IsActive để đồng bộ
        public bool IsActive { get; set; }
    }
}