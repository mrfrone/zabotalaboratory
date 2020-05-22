using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.AnalysesTests.Forms
{
    public class NewAnalysesTestForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Number1C { get; set; }

        [Required]
        public int AnalysesTypesId { get; set; }
    }
}