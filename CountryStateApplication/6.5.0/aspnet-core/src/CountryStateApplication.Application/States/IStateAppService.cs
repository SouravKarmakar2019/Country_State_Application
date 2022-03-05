using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CountryStateApplication.States.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryStateApplication.States
{
    public interface IStateAppService : IApplicationService
    {
        Task<List<StateDto>> GetAll();

        Task<StateDto> GetAsync(Guid id);

        Task<StateDto> CreateAsync(CreateStateDto input);

        Task<StateDto> UpdateAsync(StateDto input);

        Task DeleteAsync(EntityDto<Guid> input);
    }
}
