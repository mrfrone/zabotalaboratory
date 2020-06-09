using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class Talons
    {
        public virtual int Id { get; set; }

        [Required]
        [ForeignKey(nameof(AnalysesType))]
        public virtual int AnalysesTypeId { get; set; }
        [Required]
        public virtual AnalysesTypes AnalysesType { get; set; }

        public virtual List<AnalysesResult> AnalysesResult { get; set; }

        public virtual string PerformedBy { get; set; }

    }
}
