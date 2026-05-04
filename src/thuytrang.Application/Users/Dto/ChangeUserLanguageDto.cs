using System.ComponentModel.DataAnnotations;

namespace thuytrang.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}