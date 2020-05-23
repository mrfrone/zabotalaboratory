using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class AnalysesTypes
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual int Number1C { get; set; }

        [Required]
        public virtual bool IsValid { get; set; }
        
        public virtual List<LaboratoryAnalysesTests> LaboratoryAnalysesTests { get; set; }
    }
}
