using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Datamodel.Analyses
{
    public class ZabotaAnalysesTypesAddForm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number1C { get; set; }    

        public bool IsNeeded { get; set; }
        
        public IEnumerable<ZabotaLaboratoryAnalysesTestsAddForm> LaboratoryAnalysesTests { get; set; }
    }
}
