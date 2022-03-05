using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CountryStateApplication.Configuration.Dto;

namespace CountryStateApplication.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CountryStateApplicationAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
