using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace CountryStateApplication.States.Dto
{
    [AutoMapTo(typeof(State))]
    public class CreateStateDto
    {
        public const int MaxNameLength = 255;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public Guid CountryId { get; set; }
    }
}
