using System.ComponentModel.DataAnnotations;
using zabotalaboratory.Common.Datamodel.Abstractions;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class LaboratoryAnalysesTests : IValidatable
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual int Number1C { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual bool IsValid { get; set; }

        [Required]
        public virtual int AnalysesTypesId { get; set; }

        public virtual string Units { get; set; }

        public virtual string ReferenceLimits { get; set; }
    }
}
