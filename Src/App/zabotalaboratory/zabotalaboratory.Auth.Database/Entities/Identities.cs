﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zabotalaboratory.Auth.Database.Entities
{
    public class Identities
    {
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public virtual string Login { get; set; }

        [Required]
        [MaxLength(32)]
        public virtual string Password { get; set; }

        [Required]
        [ForeignKey(nameof(Role))]
        public virtual int RoleId { get; set; }

        [Required]
        public virtual Roles Role { get; set; }

        public virtual int? ClinicId { get; set; }

        public virtual string ClinicName { get; set; }

        public virtual bool? IsDeleted { get; set; }

        public virtual int? DeletedById { get; set; }

        public virtual DateTimeOffset? Deleted { get; set; }
    }
}
