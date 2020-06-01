using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Identities.Forms
{
    public class UpdateSubRoleForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
