using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Forms.LaboratoryAnalyses
{
    public class AddTalonsForm
    {
        public int AnalysesTypeId { get; set; }

        public IEnumerable<AddAnalysesResultForm> AnalysesResult { get; set; }
    }
}
