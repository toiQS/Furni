using System.ComponentModel.DataAnnotations;

namespace furni.Presentation.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
