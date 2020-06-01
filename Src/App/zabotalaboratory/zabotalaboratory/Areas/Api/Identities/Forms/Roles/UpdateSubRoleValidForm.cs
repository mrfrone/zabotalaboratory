using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Identities.Forms
{
    public class UpdateSubRoleValidForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsValid { get; set; }
    }
}
