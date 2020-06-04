using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Clinics.Forms
{
    public class AddClinicForm
    {
        [Required]
        public string Name { get; set; }
    }
}
