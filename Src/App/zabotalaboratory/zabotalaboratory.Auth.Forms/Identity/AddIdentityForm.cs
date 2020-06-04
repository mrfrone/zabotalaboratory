namespace zabotalaboratory.Auth.Forms.Identity
{
    public class AddIdentityForm
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public int? ClinicId { get; set; }

        public string ClinicName { get; set; }
    }
}
