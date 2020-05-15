using System.Threading.Tasks;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Auth.Forms.Login;

namespace zabotalaboratory.Auth.Database.Repository.Identities
{
    public interface IIdentitiesRepository
    {
        Task<Entities.Identities[]> Get();

        Task<Entities.Identities> IdentityByTokenId(int id);

        Task<Entities.Identities> IdentityByLogin(string login);

        Task<Entities.Identities> GetByLoginAndPassword(LoginForm form);

        Task<bool> IdentityExistsAsync(int identityId);

        Task<Roles[]> GetRoles(bool trackChanges = false);

        Task<SubRoles[]> GetSubRoles(bool trackChanges = false);

        Task Add(LoginForm form);

        Task<bool> Delete(int identityId, int actorId);
    }
}
