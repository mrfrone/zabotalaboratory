using System.Threading.Tasks;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Auth.Forms.Identity;
using zabotalaboratory.Auth.Forms.Login;
using zabotalaboratory.Auth.Forms.Roles;

namespace zabotalaboratory.Auth.Database.Repository.Identities
{
    public interface IIdentitiesRepository
    {
        Task<Entities.Identities[]> Get(bool trackChanges = false);

        Task<Entities.Identities> IdentityById(int id, bool trackChanges = false);

        Task<Entities.Identities> IdentityByTokenId(int id, bool trackChanges = false);

        Task<Entities.Identities> IdentityByLogin(string login, bool trackChanges = false);

        Task<Entities.Identities> GetByLoginAndPassword(LoginForm form, bool trackChanges = false);

        Task Add(AddIdentityForm form);

        Task<bool> Update(UpdateIdentityForm form);

        Task Delete(int identityId, int actorId);

        Task<Roles[]> GetRoles(bool trackChanges = false);

        Task<SubRoles[]> GetSubRoles(bool onlyValid, bool trackChanges = false);

        Task<SubRoles> GetSubRoleById(int id, bool trackChanges = false);

        Task<bool> AddSubRole(AddNewSubRoleForm form);

        Task<bool> UpdateSubRole(UpdateSubRoleForm form);

        Task UpdateSubRoleValid(UpdateSubRoleValidForm form);
    }
}
