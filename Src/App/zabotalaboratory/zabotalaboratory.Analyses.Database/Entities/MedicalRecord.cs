using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class MedicalRecord
    {
        [Key]
        [ForeignKey(nameof(LaboratoryAnalyses))]
        public virtual int LaboratoryAnalysesId { get; set; }

        public virtual LaboratoryAnalyses LaboratoryAnalyses { get; set; }

        public virtual string InsuranceName { get; set; }

        public virtual string PolicyNumber { get; set; }

        public virtual string SnilsNumber { get; set; }

        public virtual string PrivilegeCode { get; set; }

        public virtual string PermanentAddress { get; set; }

        public virtual string ActualAddress { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string PreferentialProvision { get; set; }

        public virtual string Disability { get; set; }

        public virtual string PlaceOfWork { get; set; }

        public virtual string Profession { get; set; }

        public virtual string Position { get; set; }

        public virtual string Dependent { get; set; }
    }
}
