using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class LaboratoryAnalyses
    {
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public virtual string LastName { get; set; }

        [Required]
        [MaxLength(32)]
        public virtual string FirstName { get; set; }

        [Required]
        [MaxLength(32)]
        public virtual string PatronymicName { get; set; }

        [Required]
        public virtual DateTimeOffset DateOfBirth { get; set; }

        [Required]
        [ForeignKey(nameof(Clinic))]
        public virtual int ClinicId { get; set; }

        [Required]
        public virtual Clinics Clinic { get; set; }
        
        [Required]
        public virtual DateTimeOffset PickUpDate { get; set; }

        public virtual List<Talons> Talons { get; set; }
    }
}
