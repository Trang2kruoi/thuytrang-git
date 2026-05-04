using System.Threading.Tasks;
using thuytrang.Configuration.Dto;

namespace thuytrang.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
