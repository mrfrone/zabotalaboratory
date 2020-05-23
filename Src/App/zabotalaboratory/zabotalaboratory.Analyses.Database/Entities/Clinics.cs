using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class Clinics
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }
    }
}
