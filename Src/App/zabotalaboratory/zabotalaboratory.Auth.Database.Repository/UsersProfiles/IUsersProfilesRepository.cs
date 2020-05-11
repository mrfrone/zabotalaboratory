using System.Threading.Tasks;
using zabotalaboratory.Auth.Database.Entities;

namespace zabotalaboratory.Auth.Database.Repository.UserProfiles
{
    public interface IUserProfilesRepository
    {
        Task<UsersProfiles> GetByIdentityId(int identityId, bool trackChanges = false);
    }
}