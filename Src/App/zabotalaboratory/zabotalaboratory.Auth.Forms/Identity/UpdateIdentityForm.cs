namespace zabotalaboratory.Auth.Forms.Identity
{
    public class UpdateIdentityForm
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool ChangePassword { get; set; }

        public int RoleId { get; set; }

        public int? ClinicId { get; set; }

        public string ClinicName { get; set; }
    }
}
