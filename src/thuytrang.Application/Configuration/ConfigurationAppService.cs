using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using thuytrang.Configuration.Dto;

namespace thuytrang.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : thuytrangAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
