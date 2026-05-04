using Abp.Application.Services;
using thuytrang.MultiTenancy.Dto;

namespace thuytrang.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

