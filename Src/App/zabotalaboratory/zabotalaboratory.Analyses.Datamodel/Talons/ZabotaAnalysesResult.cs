using zabotalaboratory.Analyses.Datamodel.Analyses;

namespace zabotalaboratory.Analyses.Datamodel.Talons
{
    public class ZabotaAnalysesResult
    {
        public int Id { get; set; }

        public string Result { get; set; }

        public ZabotaLaboratoryAnalysesTests LaboratoryAnalysesTest { get; set; }

        public string Units { get; set; }

        public string ReferenceLimits { get; set; }
    }
}
