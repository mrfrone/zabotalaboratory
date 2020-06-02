using System.Threading.Tasks;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Auth.Forms.UsersProfiles;

namespace zabotalaboratory.Auth.Database.Repository.UserProfiles
{
    public interface IUsersProfilesRepository
    {
        Task<UsersProfiles> GetByIdentityId(int identityId, bool trackChanges = false);

        Task AddByIdentityId(int identityId);

        Task Update(UpdateUserProfileForm form);
    }
}