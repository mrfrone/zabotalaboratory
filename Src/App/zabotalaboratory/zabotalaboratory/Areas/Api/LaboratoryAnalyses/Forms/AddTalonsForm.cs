using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.LaboratoryAnalyses.Forms
{
    public class AddTalonsForm
    {
        [Required]
        public int AnalysesTypeId { get; set; }

        [Required]
        public IEnumerable<AddAnalysesResultForm> AnalysesResult { get; set; }

        [Required]
        public bool IsNeeded { get; set; }
    }
}
