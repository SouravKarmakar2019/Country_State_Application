using System.Threading.Tasks;
using CountryStateApplication.Configuration.Dto;

namespace CountryStateApplication.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
