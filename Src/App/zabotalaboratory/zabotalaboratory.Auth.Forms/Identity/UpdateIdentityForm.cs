﻿namespace zabotalaboratory.Auth.Forms.Identity
{
    public class UpdateIdentityForm
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public int? SubRoleId { get; set; }
    }
}