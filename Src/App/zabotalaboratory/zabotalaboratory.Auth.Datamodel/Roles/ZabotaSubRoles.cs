using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace zabotalaboratory.Auth.Datamodel.Roles
{
    public class ZabotaSubRoles
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
    }
}
