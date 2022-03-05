using System.Threading.Tasks;
using Abp.Application.Services;
using CountryStateApplication.Authorization.Accounts.Dto;

namespace CountryStateApplication.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
