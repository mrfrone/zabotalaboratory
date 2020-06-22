using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using zabotalaboratory.Common.Datamodel.Abstractions;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class AnalysesTypes : IValidatable
    {
        public virtual int Id { get; set; }

        public virtual int NumberInOrder { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string ExcelName { get; set; }

        public virtual string PDFName { get; set; }

        [Required]
        public virtual int Number1C { get; set; }

        [Required]
        public virtual bool IsValid { get; set; }
        
        public virtual List<LaboratoryAnalysesTests> LaboratoryAnalysesTests { get; set; }

        public virtual string BioMaterial { get; set; }
    }
}
