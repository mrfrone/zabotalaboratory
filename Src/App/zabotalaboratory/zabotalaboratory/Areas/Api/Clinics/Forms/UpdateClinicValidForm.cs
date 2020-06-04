using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.Clinics.Forms
{
    public class UpdateClinicValidForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsValid { get; set; }
    }
}
