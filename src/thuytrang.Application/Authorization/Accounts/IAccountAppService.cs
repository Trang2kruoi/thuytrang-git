using System.Threading.Tasks;
using Abp.Application.Services;
using thuytrang.Authorization.Accounts.Dto;

namespace thuytrang.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
