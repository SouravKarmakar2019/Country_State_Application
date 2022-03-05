using Abp.Application.Services;
using CountryStateApplication.MultiTenancy.Dto;

namespace CountryStateApplication.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

