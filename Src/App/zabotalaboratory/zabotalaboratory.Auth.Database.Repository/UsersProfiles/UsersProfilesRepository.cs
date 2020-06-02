using System.Threading.Tasks;
using zabotalaboratory.Auth.Database.Context;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Auth.Forms.UsersProfiles;

namespace zabotalaboratory.Auth.Database.Repository.UserProfiles
{
    internal class UsersProfilesRepository : IUsersProfilesRepository
    {
        private readonly AuthContext _ac;

        public UsersProfilesRepository(AuthContext dc)
        {
            _ac = dc;
        }

        public Task<UsersProfiles> GetByIdentityId(int identityId, bool trackChanges = false)
        {
            return _ac.UsersProfiles
                .HasTracking(trackChanges)
                .Include(u => u.Identity)
                .FirstOrDefaultAsync(u => u.IdentityId == identityId);
        }

        public async Task AddByIdentityId(int identityId)
        {
            _ac.UsersProfiles.Add(new UsersProfiles {
                IdentityId = identityId
            });

            await _ac.SaveChangesAsync();
        }

        public async Task Update(UpdateUserProfileForm form)
        {
            var profile = await GetByIdentityId(form.IdentityId, true);

            profile.AbbreviatedNameOfCompany = form.AbbreviatedNameOfCompany;
            profile.FullNameOfCompany = form.FullNameOfCompany;
            profile.Address = form.Address;
            profile.Email = form.Email;

            await _ac.SaveChangesAsync();
        }
    }
}