﻿using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Auth.Database.Entities
{
    public class SubRoles
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual bool IsValid { get; set; }
    }
}
