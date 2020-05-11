using System;
using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Auth.Database.Entities
{
    public class Identities
    {
        [Required]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Login { get; set; }

        [Required]
        public virtual string Password { get; set; }

        [Required]
        public virtual bool IsBanned { get; set; }

        [Required]
        public virtual bool? IsDeleted { get; set; }

        [Required]
        public virtual int? DeletedById { get; set; }

        [Required]
        public DateTimeOffset? Deleted { get; set; }

        [Required]
        public virtual string Role { get; set; }
    }
}
