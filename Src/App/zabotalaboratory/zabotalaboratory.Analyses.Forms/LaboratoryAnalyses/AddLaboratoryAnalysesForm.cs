using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Forms.LaboratoryAnalyses
{
    public class AddLaboratoryAnalysesForm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PatronymicName { get; set; }

        public string DateOfBirth { get; set; }

        public int GenderId { get; set; }

        public int ClinicId { get; set; }

        public string Doctor { get; set; }

        public IEnumerable<AddTalonsForm> Talons { get; set; }

    }
}
