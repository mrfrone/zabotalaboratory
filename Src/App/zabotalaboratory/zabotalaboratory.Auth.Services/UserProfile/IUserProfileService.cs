using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.UserProfiles;
using zabotalaboratory.Auth.Forms.UsersProfiles;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Auth.Services.UserProfile
{
    public interface IUserProfileService
    {
        Task<ZabotaResult<ZabotaUserProfile>> GetByIdentityId(int identityId);

        Task<ZabotaResult<bool>> UpdateUserProfile(UpdateUserProfileForm form);

        Task<ZabotaResult<string>> GetAbbreviatedNameOfCompany(int identityId);
    }
}