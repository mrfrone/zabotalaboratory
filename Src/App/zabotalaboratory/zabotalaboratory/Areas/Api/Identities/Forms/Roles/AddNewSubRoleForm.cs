using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Identities.Forms
{
    public class AddNewSubRoleForm
    {
        [Required]
        public string Name { get; set; }
    }
}
