using Abp.Authorization;
using CountryStateApplication.Authorization;
using CountryStateApplication.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CountryStateApplication.Countries
{
    [AbpAuthorize(PermissionNames.Pages_Country)]
    public class CountryAppService: CountryStateApplicationAppServiceBase, ICountryAppService
    {
        private readonly IRepository<Country, Guid> _countryRepository;
        public CountryAppService(IRepository<Country, Guid> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<CountryDto>> GetAll()
        {
            var country = await _countryRepository
            .GetAll()
            .ToListAsync();

            return ObjectMapper.Map<List<CountryDto>>(country);
        }

        public async Task<CountryDto> GetAsync(Guid id)
        {
            var country = await _countryRepository
            .FirstOrDefaultAsync(id);

            return ObjectMapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> CreateAsync(CreateCountryDto input)
        {
            var country = ObjectMapper.Map<Country>(input);

            await _countryRepository.InsertAsync(country);

            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> UpdateAsync(CountryDto input)
        {
            var country = ObjectMapper.Map<Country>(input);

            await _countryRepository.UpdateAsync(country);

            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<CountryDto>(country);
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            await _countryRepository.DeleteAsync(input.Id);
        }
    }
}
