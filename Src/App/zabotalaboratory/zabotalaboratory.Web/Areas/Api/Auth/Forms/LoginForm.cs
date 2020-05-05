using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Auth.Forms
{
    public class LoginForm
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}