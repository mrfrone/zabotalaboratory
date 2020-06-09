using System;
using System.Collections.Generic;
using zabotalaboratory.Analyses.Datamodel.Clinics;
using zabotalaboratory.Analyses.Datamodel.Talons;

namespace zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses
{
    public class ZabotaLaboratoryAnalyses
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string PatronymicName { get; set; }

        public string FullName => $"{LastName} {FirstName} {PatronymicName}";

        public DateTimeOffset DateOfBirth { get; set; }

        public ZabotaClinics Clinic { get; set; }

        public DateTimeOffset PickUpDate { get; set; }

        public string Doctor { get; set; }

        public IEnumerable<ZabotaTalons> Talons { get; set; }
    }
}
