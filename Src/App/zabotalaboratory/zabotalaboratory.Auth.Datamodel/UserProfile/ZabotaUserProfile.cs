﻿namespace zabotalaboratory.Auth.Datamodel.UserProfiles
{
    public class ZabotaUserProfile
    {
        public int IdentityId { get; set; }

        public string AbbreviatedNameOfCompany { get; set; }

        public string FullNameOfCompany { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}