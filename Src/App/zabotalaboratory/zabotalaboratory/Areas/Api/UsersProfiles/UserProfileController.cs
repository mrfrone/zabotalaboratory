using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Auth.Services.UserProfile;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Areas.Api.Auth
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

        
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<string>> GetRole()
        {
            return await _userProfileService.GetRoleByIdentityId(CurrentIdentity.Id);
        }
    }
}