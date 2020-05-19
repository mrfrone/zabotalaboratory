using System.Collections.Generic;
using zabotalaboratory.Analyses.Datamodel.Analyses;

namespace zabotalaboratory.Analyses.Datamodel.Talons
{
    public class ZabotaTalons
    {
        public int Id { get; set; }

        public ZabotaAnalysesTypes AnalysesType { get; set; }

        public IEnumerable<ZabotaAnalysesResult> AnalysesResult { get; set; }

    }
}
