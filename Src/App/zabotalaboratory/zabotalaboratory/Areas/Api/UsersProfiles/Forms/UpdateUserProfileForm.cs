using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Web.Areas.Api.UsersProfiles.Forms
{
    public class UpdateUserProfileForm
    {
        [Required]
        [MaxLength(64)]
        public string AbbreviatedNameOfCompany { get; set; }

        [Required]
        [MaxLength(128)]
        public string FullNameOfCompany { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Address { get; set; }
    }
}
