using System.Threading.Tasks;
using Abp.Application.Services;
using thuytrang.Sessions.Dto;

namespace thuytrang.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
