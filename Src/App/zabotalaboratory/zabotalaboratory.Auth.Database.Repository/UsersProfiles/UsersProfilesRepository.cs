using System.Threading.Tasks;
using zabotalaboratory.Auth.Database.Context;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace zabotalaboratory.Auth.Database.Repository.UserProfiles
{
    internal class UserProfilesRepository : IUserProfilesRepository
    {
        private readonly AuthContext _dc;

        public UserProfilesRepository(AuthContext dc)
        {
            _dc = dc;
        }
        
        public Task<UsersProfiles> GetByIdentityId(int identityId, bool trackChanges = false)
        {
            return _dc.UsersProfiles
                .HasTracking(trackChanges)
                .Include(u => u.Identity)
                .FirstOrDefaultAsync(u => u.IdentityId == identityId);
        }
    }
}