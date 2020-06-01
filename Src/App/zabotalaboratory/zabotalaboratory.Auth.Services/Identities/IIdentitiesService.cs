using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Auth.Datamodel.Roles;
using zabotalaboratory.Auth.Forms.Identity;
using zabotalaboratory.Auth.Forms.Roles;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Auth.Services.Identities
{
    public interface IIdentityService
    {
        Task<ZabotaResult<IEnumerable<ZabotaIdentity>>> GetIdentities();

        Task<ZabotaResult<ZabotaIdentity>> GetIdentityById(int id);

        Task<ZabotaIdentity> GetIdentityByTokenId(int id);

        Task<ZabotaResult<bool>> AddIdentity(AddIdentityForm form);

        Task<ZabotaResult<bool>> UpdateIdentity(UpdateIdentityForm form);

        Task<ZabotaResult<bool>> DeleteIdentity(int id, int actorId);

        Task<ZabotaResult<IEnumerable<ZabotaRoles>>> GetRoles();

        Task<ZabotaResult<IEnumerable<ZabotaSubRoles>>> GetSubRoles(bool onlyValid);

        Task<ZabotaResult<ZabotaSubRoles>> GetSubRoleById(int id);

        Task<ZabotaResult<bool>> AddSubRole(AddNewSubRoleForm form);

        Task<ZabotaResult<bool>> UpdateSubRole(UpdateSubRoleForm form);

        Task<ZabotaResult<bool>> UpdateSubRoleValid(UpdateSubRoleValidForm form);

    }
}