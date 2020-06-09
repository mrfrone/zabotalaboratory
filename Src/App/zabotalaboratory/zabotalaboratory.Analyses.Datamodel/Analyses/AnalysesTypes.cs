using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Datamodel.Analyses
{
    public class ZabotaAnalysesTypes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number1C { get; set; }    

        public bool IsValid { get; set; }
        
        public IEnumerable<ZabotaLaboratoryAnalysesTests> LaboratoryAnalysesTests { get; set; }

        public string BioMaterial { get; set; }
    }
}
