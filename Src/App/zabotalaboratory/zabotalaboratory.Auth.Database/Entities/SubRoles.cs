using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace zabotalaboratory.Auth.Database.Entities
{
    public class SubRoles
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
    }
}
