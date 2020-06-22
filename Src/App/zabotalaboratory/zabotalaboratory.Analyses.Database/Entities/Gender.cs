using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Analyses.Database.Entities
{
    public class Gender
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string ShortName { get; set; }
    }
}
