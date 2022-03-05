using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace CountryStateApplication.Countries.Dto
{
    public class CountryDto: EntityDto<Guid>
    {
        public const int MaxNameLength = 255;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }
}
