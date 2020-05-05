using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Auth.Services.Identities;

namespace zabotalaboratory.Web.Common.Storage
{
    internal class IdentityRequestStorage : IIdentityRequestStorage
    {
        private readonly IIdentityService _identityService;

        public ZabotaIdentity Current { get; private set; }

        public IdentityRequestStorage(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ZabotaIdentity> Ensure(int tokenId)
        {
            if (Current != null)
                return Current;

            var identity = await _identityService.GetIdentityByTokenId(tokenId);

            if (identity != null)
                Current = identity;

            return Current;
        }
    }
}