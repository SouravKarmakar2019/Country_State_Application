using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace CountryStateApplication.Countries.Dto
{
    [AutoMapTo(typeof(Country))]
    public class CreateCountryDto
    {
        public const int MaxNameLength = 255;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }
}
