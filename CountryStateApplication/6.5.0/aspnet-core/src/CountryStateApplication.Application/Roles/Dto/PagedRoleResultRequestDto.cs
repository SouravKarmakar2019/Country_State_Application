using Abp.Application.Services.Dto;

namespace CountryStateApplication.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

