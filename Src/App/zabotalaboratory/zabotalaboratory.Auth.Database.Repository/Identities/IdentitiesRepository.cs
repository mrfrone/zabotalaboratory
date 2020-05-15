using zabotalaboratory.Auth.Database.Repository.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using zabotalaboratory.Common.PasswordService.PasswordHash;
using System;
using zabotalaboratory.Auth.Database.Context;
using zabotalaboratory.Auth.Forms.Login;

namespace zabotalaboratory.Auth.Database.Repository.Identities
{
    internal class IdentitiesRepository : IIdentitiesRepository
    {
        private readonly AuthContext _ac;
        private readonly ITokensRepository _tokensRepository;
        private readonly IPasswordHashCalculator _passwordHashCalculator;

        public IdentitiesRepository(AuthContext ac, ITokensRepository tokensRepository, IPasswordHashCalculator passwordHashCalculator)
        {
            _ac = ac;
            _tokensRepository = tokensRepository;
            _passwordHashCalculator = passwordHashCalculator;
        }
        public async Task<Entities.Identities[]> Get()
        {
            return await _ac.Identities
                .Include(u => u.Role)
                .Include(u => u.SubRole)
                .Where(x => x.IsDeleted != true)
                .ToArrayAsync();
        }
        public async Task<Entities.Identities> IdentityByTokenId(int id)
        {
            var jwt = await _tokensRepository.GetById(id);
            if (jwt == null || jwt.IsDeleted)
                return null;

            return await _ac.Identities
                .Include(u => u.Role)
                .Include(u => u.SubRole)
                .FirstOrDefaultAsync(u => u.Id == jwt.IdentityId && u.IsDeleted != true);
        }
        public async Task<Entities.Identities> IdentityByLogin(string login)
        {
            return await _ac.Identities
                .Include(u => u.Role)
                .Include(u => u.SubRole)
                .FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<Entities.Identities> GetByLoginAndPassword(LoginForm form)
        {
            var login = form.Login.Trim();

            var user = await _ac.Identities
                .Include(u => u.Role)
                .Include(u => u.SubRole)
                .FirstOrDefaultAsync(u => u.Login == login && u.IsDeleted != true);

            return user;
        }
        public Task<bool> IdentityExistsAsync(int identityId)
        {
            return _ac.Identities.AnyAsync(u => u.Id == identityId && u.IsDeleted != true);
        }
        public Task Add(LoginForm form)
        {
            _ac.Identities.Add(new Entities.Identities
            {
                Login = form.Login,
                Password = _passwordHashCalculator.Calc(form.Password),
                IsDeleted = false,
                RoleId = 1,
                SubRoleId = 1
            });

            return _ac.SaveChangesAsync();
        }
        public async Task<bool> Delete(int identityId, int actorId)
        {
            var identity = await _ac.Identities.FirstOrDefaultAsync(u => u.Id == identityId && u.IsDeleted != true);
            if (identity == null)
                return false;

            identity.Deleted = DateTimeOffset.UtcNow;
            identity.DeletedById = actorId;
            identity.IsDeleted = true;

            _ac.SaveChanges();
            return true;
        }

    }
}

