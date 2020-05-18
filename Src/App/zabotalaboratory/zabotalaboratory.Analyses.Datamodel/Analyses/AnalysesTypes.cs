using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Datamodel.Analyses
{
    public class ZabotaAnalysesTypes
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int Number1C { get; set; }    
        
        public virtual IEnumerable<ZabotaLaboratoryAnalysesTests> LaboratoryAnalysesTests { get; set; }
    }
}
