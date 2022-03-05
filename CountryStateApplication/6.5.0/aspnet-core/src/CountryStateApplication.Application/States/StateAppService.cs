using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using CountryStateApplication;
using CountryStateApplication.Authorization;
using CountryStateApplication.States;
using CountryStateApplication.States.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StateStateApplication.States
{
    [AbpAuthorize(PermissionNames.Pages_State)]
    public class StateAppService : CountryStateApplicationAppServiceBase, IStateAppService
    {
        private readonly IRepository<State, Guid> _stateRepository;
        public StateAppService(IRepository<State, Guid> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<List<StateDto>> GetAll()
        {
            var state = await _stateRepository
            .GetAll()
            .Include(e => e.Country)
            .ToListAsync();

            return ObjectMapper.Map<List<StateDto>>(state);
        }

        public async Task<StateDto> GetAsync(Guid id)
        {
            var state = await _stateRepository
            .FirstOrDefaultAsync(id);

            return ObjectMapper.Map<StateDto>(state);
        }

        public async Task<StateDto> CreateAsync(CreateStateDto input)
        {
            var state = ObjectMapper.Map<State>(input);

            await _stateRepository.InsertAsync(state);

            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<StateDto>(state);
        }

        public async Task<StateDto> UpdateAsync(StateDto input)
        {
            var state = ObjectMapper.Map<State>(input);

            await _stateRepository.UpdateAsync(state);

            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<StateDto>(state);
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            await _stateRepository.DeleteAsync(input.Id);
        }
    }
}