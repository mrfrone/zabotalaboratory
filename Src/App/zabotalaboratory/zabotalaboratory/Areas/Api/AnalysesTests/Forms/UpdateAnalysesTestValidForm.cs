using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.AnalysesTests.Forms
{
    public class UpdateAnalysesTestValidForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsValid { get; set; }
    }
}