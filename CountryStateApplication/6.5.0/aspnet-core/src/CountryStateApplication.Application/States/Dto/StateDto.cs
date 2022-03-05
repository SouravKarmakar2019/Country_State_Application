using Abp.Application.Services.Dto;
using CountryStateApplication.Countries;
using System;
using System.ComponentModel.DataAnnotations;

namespace CountryStateApplication.States.Dto
{
    public class StateDto : EntityDto<Guid>
    {
        public const int MaxNameLength = 255;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }
        public Country Country { get; set; }
        [Required]
        public Guid CountryId { get; set; }
    }
}
