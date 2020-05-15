using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Auth.Datamodel.Roles;
using zabotalaboratory.Auth.Forms.Login;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Auth.Services.Identities
{
    public interface IIdentityService
    {
        Task<ZabotaResult<IEnumerable<ZabotaIdentity>>> GetIdentities();

        Task<ZabotaIdentity> GetIdentityByTokenId(int id);

        Task<ZabotaResult<IEnumerable<ZabotaRoles>>> GetRoles();

        Task<ZabotaResult<IEnumerable<ZabotaSubRoles>>> GetSubRoles();

        Task<bool> AddIdentity(LoginForm form);

        Task<bool> DeleteIdentity(int id, int actorId);

    }
}