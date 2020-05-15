using System;
using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class LaboratoryAnalyses
    {
        public virtual int Id { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string PatronymicName { get; set; }

        public virtual DateTimeOffset DateOfBirth { get; set; }

        public virtual int ClinicId { get; set; }

        public virtual Clinics Clinic { get; set; }

        public virtual DateTimeOffset PickUpDate { get; set; }

        public virtual List<Talons> Talons { get; set; }
    }
}
