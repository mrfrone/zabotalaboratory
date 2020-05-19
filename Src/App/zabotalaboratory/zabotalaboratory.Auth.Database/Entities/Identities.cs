﻿using System;
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
        public virtual int RoleId { get; set; }

        [Required]
        public virtual Roles Role { get; set; }

        public virtual int? SubRoleId { get; set; }
        public virtual SubRoles SubRole { get; set; }

        public virtual bool? IsDeleted { get; set; }

        public virtual int? DeletedById { get; set; }

        public virtual DateTimeOffset? Deleted { get; set; }
    }
}
