using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Auth.Database.Entities
{
    public class Roles
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }
    }
}
