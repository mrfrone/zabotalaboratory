using zabotalaboratory.Auth.Datamodel.Identities;
using System.Threading.Tasks;

namespace zabotalaboratory.Web.Common.Storage
{
    public interface IIdentityRequestStorage
    {
        Task<ZabotaIdentity> Ensure(int tokenId);
        ZabotaIdentity Current { get; }
    }
}