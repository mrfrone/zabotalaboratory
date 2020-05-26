using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Auth.Datamodel.Roles;
using zabotalaboratory.Auth.Forms.Identity;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Auth.Services.Identities
{
    public interface IIdentityService
    {
        Task<ZabotaResult<IEnumerable<ZabotaIdentity>>> GetIdentities();

        Task<ZabotaResult<ZabotaIdentity>> GetIdentityById(int id);

        Task<ZabotaIdentity> GetIdentityByTokenId(int id);

        Task<ZabotaResult<IEnumerable<ZabotaRoles>>> GetRoles();

        Task<ZabotaResult<IEnumerable<ZabotaSubRoles>>> GetSubRoles();

        Task<ZabotaResult<bool>> AddIdentity(AddIdentityForm form);

        Task<ZabotaResult<bool>> UpdateIdentity(UpdateIdentityForm form);

        Task<ZabotaResult<bool>> DeleteIdentity(int id, int actorId);

    }
}