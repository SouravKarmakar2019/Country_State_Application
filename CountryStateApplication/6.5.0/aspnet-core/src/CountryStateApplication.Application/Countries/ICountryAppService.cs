using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CountryStateApplication.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryStateApplication.Countries
{
    public interface ICountryAppService : IApplicationService
    {
        Task<List<CountryDto>> GetAll();

        Task<CountryDto> GetAsync(Guid id);

        Task<CountryDto> CreateAsync(CreateCountryDto input);

        Task<CountryDto> UpdateAsync(CountryDto input);

        Task DeleteAsync(EntityDto<Guid> input);
    }
}
