using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Identities.Forms
{
    public class UpdateIdentityForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Login { get; set; }

        [MaxLength(32)]
        public string Password { get; set; }

        [Required]
        public bool ChangePassword { get; set; }

        [Required]
        public int RoleId { get; set; }

        public int? ClinicId { get; set; }

        public string ClinicName { get; set; }
    }
}