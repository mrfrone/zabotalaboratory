using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.UserProfiles;
using zabotalaboratory.Auth.Services.UserProfile;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Areas.Api.UsersProfiles.Forms;
using zabotalaboratory.Web.Common.Filters;

namespace zabotalaboratory.Web.Areas.Api.UsersProfiles
{
    [Authorize]
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class UserProfileController : BaseController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaUserProfile>> GetUserProfile()
        {
            return await _userProfileService.GetByIdentityId(CurrentIdentity.Id);
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateUserProfile([FromBody] UpdateUserProfileForm form)
        {
            return await _userProfileService.UpdateUserProfile(new zabotalaboratory.Auth.Forms.UsersProfiles.UpdateUserProfileForm {
                IdentityId = CurrentIdentity.Id,
                AbbreviatedNameOfCompany = form.AbbreviatedNameOfCompany,
                FullNameOfCompany = form.FullNameOfCompany,
                Address = form.Address,
                Email = form.Email
            });
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<string>> GetAbbreviatedNameOfCompany()
        {
            return await _userProfileService.GetAbbreviatedNameOfCompany(CurrentIdentity.Id);
        }
    }
}