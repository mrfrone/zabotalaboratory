using System.Threading.Tasks;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Auth.Forms.Identity;
using zabotalaboratory.Auth.Forms.Login;

namespace zabotalaboratory.Auth.Database.Repository.Identities
{
    public interface IIdentitiesRepository
    {
        Task<Entities.Identities[]> GetIdentities(bool trackChanges = false);

        Task<Entities.Identities> IdentityById(int id, bool trackChanges = false);

        Task<Entities.Identities> IdentityByTokenId(int id, bool trackChanges = false);

        Task<Entities.Identities> IdentityByLogin(string login, bool trackChanges = false);

        Task<Entities.Identities> GetByLoginAndPassword(LoginForm form, bool trackChanges = false);

        Task Add(AddIdentityForm form);

        Task<bool> Update(UpdateIdentityForm form);

        Task Delete(int identityId, int actorId);

        Task<Roles[]> GetRoles(bool trackChanges = false);
    }
}
