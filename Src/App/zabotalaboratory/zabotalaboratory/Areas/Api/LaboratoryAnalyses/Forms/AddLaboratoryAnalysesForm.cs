using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.LaboratoryAnalyses.Forms
{
    public class AddLaboratoryAnalysesForm
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PatronymicName { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        public int ClinicId { get; set; }

        [Required]
        public string Doctor { get; set; }

        [Required]
        public IEnumerable<AddTalonsForm> Talons { get; set; }

    }
}
