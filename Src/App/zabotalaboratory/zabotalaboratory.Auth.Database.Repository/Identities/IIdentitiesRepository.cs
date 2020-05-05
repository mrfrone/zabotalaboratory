using zabotalaboratory.Auth.Forms.Login;
using System.Threading.Tasks;

namespace zabotalaboratory.Auth.Database.Repository.Identities
{
    public interface IIdentitiesRepository
    {
        Task<Entities.Identities[]> Get();
        Task<Entities.Identities> IdentityByTokenId(int id);
        Task<Entities.Identities> IdentityByLogin(string login);
        Task<Entities.Identities> GetByLoginAndPassword(LoginForm form);
        Task<bool> IdentityExistsAsync(int identityId);
        Task Add(LoginForm form);
        Task<bool> Delete(int identityId, int actorId);
    }
}
