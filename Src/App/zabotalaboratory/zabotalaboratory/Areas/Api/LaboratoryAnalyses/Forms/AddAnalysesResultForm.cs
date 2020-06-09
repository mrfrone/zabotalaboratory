using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.LaboratoryAnalyses.Forms
{
    public class AddAnalysesResultForm
    {
        [Required]
        public int LaboratoryAnalysesTestsId { get; set; }

        [Required]
        public bool IsNeeded { get; set; }
    }
}
