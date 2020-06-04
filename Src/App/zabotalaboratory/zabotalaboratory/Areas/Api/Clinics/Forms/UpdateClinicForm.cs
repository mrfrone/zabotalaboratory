using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Clinics.Forms
{
    public class UpdateClinicForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
