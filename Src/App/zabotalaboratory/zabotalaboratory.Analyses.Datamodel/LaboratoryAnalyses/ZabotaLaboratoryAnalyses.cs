using System;
using System.Collections.Generic;
using zabotalaboratory.Analyses.Datamodel.Clinics;
using zabotalaboratory.Analyses.Datamodel.Talons;

namespace zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses
{
    public class ZabotaLaboratoryAnalyses
    {
        public virtual int Id { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string PatronymicName { get; set; }

        public virtual DateTimeOffset DateOfBirth { get; set; }

        public virtual int ClinicId { get; set; }

        public virtual ZabotaClinics Clinic { get; set; }

        public virtual DateTimeOffset PickUpDate { get; set; }

        public virtual IEnumerable<ZabotaTalons> Talons { get; set; }
    }
}
