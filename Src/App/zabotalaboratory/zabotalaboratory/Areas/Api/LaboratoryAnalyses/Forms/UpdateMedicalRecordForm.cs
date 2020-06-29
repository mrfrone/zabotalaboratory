using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Web.Areas.Api.LaboratoryAnalyses.Forms
{
    public class UpdateMedicalRecordForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string InsuranceName { get; set; }

        [Required]
        public string PolicyNumber { get; set; }

        [Required]
        public string SnilsNumber { get; set; }

        [Required]
        public string PrivilegeCode { get; set; }

        [Required]
        public string PermanentAddress { get; set; }

        [Required]
        public string ActualAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string PreferentialProvision { get; set; }

        [Required]
        public string Disability { get; set; }

        [Required]
        public string PlaceOfWork { get; set; }

        [Required]
        public string Profession { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Dependent { get; set; }
    }
}
