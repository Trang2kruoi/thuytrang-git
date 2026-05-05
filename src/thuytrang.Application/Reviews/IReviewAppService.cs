using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Threading.Tasks;
using thuytrang.Reviews.Dto;

namespace thuytrang.Reviews
{
    public interface IReviewAppService : IApplicationService
    {
        Task CreateOrEdit(CreateReviewDto input);
        Task Delete(EntityDto<Guid> input);
        Task<PagedResultDto<ReviewDto>> GetAll(PagedReviewResultRequestDto input);
        Task<ReviewDto> GetAsync(EntityDto<Guid> input);
    }
}