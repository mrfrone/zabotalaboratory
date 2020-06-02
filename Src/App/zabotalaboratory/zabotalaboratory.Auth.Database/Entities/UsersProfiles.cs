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

        [MaxLength(64)]
        public virtual string AbbreviatedNameOfCompany { get; set; }

        [MaxLength(128)]
        public virtual string FullNameOfCompany { get; set; }

        [MaxLength(256)]
        public virtual string Email { get; set; }

        [MaxLength(256)]
        public virtual string Address { get; set; }
    }
}