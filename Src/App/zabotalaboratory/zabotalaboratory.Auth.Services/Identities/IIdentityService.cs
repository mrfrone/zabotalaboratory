using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Auth.Forms.Login;

namespace zabotalaboratory.Auth.Services.Identities
{
    public interface IIdentityService
    {
        Task<IEnumerable<ZabotaIdentity>> GetIdentities();
        Task<ZabotaIdentity> GetIdentityByTokenId(int id);
        Task<bool> AddIdentity(LoginForm form);
        Task<bool> DeleteIdentity(int id, int actorId);
    }
}