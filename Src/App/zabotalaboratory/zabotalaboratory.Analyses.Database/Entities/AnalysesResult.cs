using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class AnalysesResult
    {
        public virtual int Id { get; set; }

        public virtual string Result { get; set; }

        [Required]
        [ForeignKey(nameof(LaboratoryAnalysesTests))]
        public virtual int LaboratoryAnalysesTestsId { get; set; }

        [Required]
        public virtual LaboratoryAnalysesTests LaboratoryAnalysesTests { get; set; }
    }
}
