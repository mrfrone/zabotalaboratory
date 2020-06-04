using zabotalaboratory.Auth.Database.Repository.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using zabotalaboratory.Common.PasswordService.PasswordHash;
using System;
using zabotalaboratory.Auth.Database.Context;
using zabotalaboratory.Auth.Forms.Login;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using zabotalaboratory.Auth.Forms.Identity;

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
        
        public async Task<Entities.Identities[]> GetIdentities(bool trackChanges = false)
        {
            return await _ac.Identities
                .Include(u => u.Role)
                .Where(x => x.IsDeleted != true)
                .HasTracking(trackChanges)
                .ToArrayAsync();
        }

        public async Task<Entities.Identities> IdentityById(int id, bool trackChanges = false)
        {
            return await _ac.Identities
                .Include(u => u.Role)
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted != true);
        }

        public async Task<Entities.Identities> IdentityByTokenId(int id, bool trackChanges = false)
        {
            var jwt = await _tokensRepository.GetById(id);
            if (jwt == null || jwt.IsDeleted)
                return null;

            return await _ac.Identities
                .Include(u => u.Role)
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(u => u.Id == jwt.IdentityId && u.IsDeleted != true);
        }

        public async Task<Entities.Identities> IdentityByLogin(string login, bool trackChanges = false)
        {
            return await _ac.Identities
                .Include(u => u.Role)
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<Entities.Identities> GetByLoginAndPassword(LoginForm form, bool trackChanges = false)
        {
            var login = form.Login.Trim();

            var user = await _ac.Identities
                .Include(u => u.Role)
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(u => u.Login == login && u.IsDeleted != true);

            return user;
        }

        public async Task Add(AddIdentityForm form)
        {
            _ac.Identities.Add(new Entities.Identities
            {
                Login = form.Login,
                Password = _passwordHashCalculator.Calc(form.Password),
                IsDeleted = false,
                RoleId = form.RoleId,
                ClinicId = form.ClinicId,
                ClinicName = form.ClinicName
            });

            await _ac.SaveChangesAsync();
        }

        public async Task<bool> Update(UpdateIdentityForm form)
        {
            var identities = _ac.Identities.FirstOrDefault(i => i.Login == form.Login && i.Id != form.Id);
            if (identities != null)
                return false;

            var identity = await IdentityById(form.Id, true);
            if (identity == null)
                return false;
            
            if (form.ChangePassword)
            {
                identity.Password = _passwordHashCalculator.Calc(form.Password);
            }
            identity.Login = form.Login;
            identity.RoleId = form.RoleId;
            identity.ClinicId = form.ClinicId;
            identity.ClinicName = form.ClinicName;

            await _ac.SaveChangesAsync();
            return true;
        }

        public async Task Delete(int identityId, int actorId)
        {
            var identity = await IdentityById(identityId, true);

            identity.Deleted = DateTimeOffset.UtcNow;
            identity.DeletedById = actorId;
            identity.IsDeleted = true;

            await _ac.SaveChangesAsync();
        }
       
        public async Task<Roles[]> GetRoles(bool trackChanges = false)
        {
            return await _ac.Roles
                .HasTracking(trackChanges)
                .ToArrayAsync();
        }

        
    }
}

