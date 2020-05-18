using zabotalaboratory.Analyses.Datamodel.Analyses;

namespace zabotalaboratory.Analyses.Datamodel.Talons
{
    public class ZabotaAnalysesResult
    {
        public virtual int Id { get; set; }

        public virtual string Result { get; set; }

        public virtual ZabotaLaboratoryAnalysesTests LaboratoryAnalysesTest { get; set; }
    }
}
