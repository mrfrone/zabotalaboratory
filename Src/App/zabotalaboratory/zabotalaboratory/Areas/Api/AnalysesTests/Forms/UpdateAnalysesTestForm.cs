using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.AnalysesTests.Forms
{
    public class UpdateAnalysesTestForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ExcelName { get; set; }

        [Required]
        public string PDFName { get; set; }

        [Required]
        public int Number1C { get; set; }

        [Required]
        public int AnalysesTypesId { get; set; }
    }
}