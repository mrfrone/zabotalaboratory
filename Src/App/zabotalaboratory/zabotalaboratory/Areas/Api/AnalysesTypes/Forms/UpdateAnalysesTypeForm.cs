using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Web.Areas.Api.AnalysesTypes.Forms
{
    public class UpdateAnalysesTypeForm
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
        public string BioMaterial { get; set; }
    }
}