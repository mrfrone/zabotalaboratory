using System.Collections.Generic;
using zabotalaboratory.Analyses.Datamodel.Analyses;

namespace zabotalaboratory.Analyses.Datamodel.Talons
{
    public class ZabotaTalons
    {
        public virtual int Id { get; set; }

        public virtual ZabotaAnalysesTypes AnalysesType { get; set; }

        public virtual IEnumerable<ZabotaAnalysesResult> AnalysesResult { get; set; }

    }
}
