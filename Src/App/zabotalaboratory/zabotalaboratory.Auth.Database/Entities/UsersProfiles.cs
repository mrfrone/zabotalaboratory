using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zabotalaboratory.Auth.Database.Entities
{
    public class UsersProfiles
    {
        [Key]
        [ForeignKey(nameof(Identity))]
        public virtual int IdentityId { get; set; }
        public Identities Identity { get; set; }

        [MaxLength(32)]
        public virtual string FirstName { get; set; }

        [MaxLength(32)]
        public virtual string LastName { get; set; }

        [MaxLength(32)]
        public virtual string PatronymicName { get; set; }

        [MaxLength(256)]
        public virtual string Email { get; set; }
    }
}