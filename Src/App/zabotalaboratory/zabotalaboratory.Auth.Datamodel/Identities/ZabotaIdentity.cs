using zabotalaboratory.Auth.Datamodel.Roles;

namespace zabotalaboratory.Auth.Datamodel.Identities
{
    public class ZabotaIdentity
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public ZabotaRoles Role { get; set; }

        public int ClinicId { get; set; }

        public string ClinicName { get; set; }
    }
}