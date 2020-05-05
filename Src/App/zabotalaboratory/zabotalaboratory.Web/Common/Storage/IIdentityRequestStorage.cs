using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.Identities;

namespace zabotalaboratory.Common.Storage
{
    public interface IIdentityRequestStorage
    {
        Task<ZabotaIdentity> Ensure(int tokenId);
        ZabotaIdentity Current { get; }
    }
}