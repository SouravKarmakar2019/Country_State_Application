using System.Threading.Tasks;
using Abp.Application.Services;
using CountryStateApplication.Sessions.Dto;

namespace CountryStateApplication.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
