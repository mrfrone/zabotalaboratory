using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class AnalysesTypes
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int Number1C { get; set; }    

        public virtual bool IsValid { get; set; }
        
        public virtual List<LaboratoryAnalysesTests> LaboratoryAnalysesTests { get; set; }
    }
}
