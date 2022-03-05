using System.ComponentModel.DataAnnotations;

namespace CountryStateApplication.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}