namespace zabotalaboratory.Auth.Datamodel.UserProfiles
{
    public class ZabotaUserProfile
    {
        public int IdentityId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PatronymicName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsBanned { get; set; }

        public string Role { get; set; }

        public string SubRole { get; set; }

        public string FullName => $"{LastName} {FirstName} {PatronymicName}";
    }
}