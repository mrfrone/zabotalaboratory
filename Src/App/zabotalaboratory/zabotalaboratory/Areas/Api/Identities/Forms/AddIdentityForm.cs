using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Identities.Forms
{
    public class AddIdentityForm
    {
        [Required]
        [MaxLength(32)]
        public string Login { get; set; }

        [Required]
        [MaxLength(32)]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        public int? SubRoleId { get; set; }
    }
}