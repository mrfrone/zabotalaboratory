using System.ComponentModel.DataAnnotations;
using zabotalaboratory.Common.Datamodel.Abstractions;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class LaboratoryAnalysesTests : IValidatable
    {
        public virtual int Id { get; set; }

        public virtual int NumberInOrder { get; set; }

        [Required]
        public virtual int Number1C { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string ExcelName { get; set; }

        public virtual string PDFName { get; set; }

        [Required]
        public virtual bool IsValid { get; set; }

        [Required]
        public virtual int AnalysesTypesId { get; set; }
    }
}
