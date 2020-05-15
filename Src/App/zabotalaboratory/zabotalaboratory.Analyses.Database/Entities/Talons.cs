using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class Talons
    {
        public virtual int Id { get; set; }

        public virtual AnalysesTypes AnalysesType { get; set; }

        public virtual List<AnalysesResult> AnalysesResult { get; set; }

    }
}
