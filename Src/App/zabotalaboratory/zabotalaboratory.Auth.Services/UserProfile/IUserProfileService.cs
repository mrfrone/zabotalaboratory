using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.UserProfiles;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Auth.Service.UserProfile
{
    public interface IUserProfileService
    {
        Task<ZabotaResult<ZabotaUserProfile>> GetByIdentityId(int identityId);
        Task<ZabotaResult<string>> GetRoleByIdentityId(int identityId);
    }
}