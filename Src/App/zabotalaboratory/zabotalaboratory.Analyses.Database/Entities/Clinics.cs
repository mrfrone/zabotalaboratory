using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Analyses.Database.Entities
{
    class Clinics
    {   
        [Required]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }
    }
}
