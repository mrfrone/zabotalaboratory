using System.ComponentModel.DataAnnotations;
using zabotalaboratory.Common.Datamodel.Abstractions;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class Clinics : IValidatable
    {
        public virtual int? Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual bool IsValid { get; set; }
    }
}
