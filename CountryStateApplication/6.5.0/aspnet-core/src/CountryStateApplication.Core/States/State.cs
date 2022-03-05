using Abp.Domain.Entities.Auditing;
using CountryStateApplication.Countries;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountryStateApplication.States
{
    [Table("State")]
    public class State : AuditedEntity<Guid>
    {
        public const int MaxNameLength = 255;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        [Required]
        [ForeignKey("CountryId")]
        public Guid CountryId { get; set; }
    }
}
