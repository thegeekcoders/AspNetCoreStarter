using System.ComponentModel.DataAnnotations;

namespace AspNetCoreStarter.ViewModels
{
    public class StudentEditViewModel
    {

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(60)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}