using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using zabotalaboratory.Auth.Database.Context;

namespace zabotalaboratory.Auth.Database.Repository.Tokens
{
    public class TokensRepository : ITokensRepository
    {
        private readonly AuthContext _ac;

        public TokensRepository(AuthContext ac)
        {
            _ac = ac;
        }

        public async Task<Jwts> IssueToken(int id, DateTimeOffset expirationDate)
        {
            var jwt = _ac.Jwts.Add(new Jwts
            {
                IsDeleted = false,
                Expires = expirationDate,
                IdentityId = id,
                Deleted = null,
                Issued = DateTimeOffset.UtcNow,
                Token = string.Empty
            }).Entity;

            await _ac.SaveChangesAsync();

            return jwt;
        }

        public async Task WriteBody(int tokenId, string token)
        {
            var jwt = await GetById(tokenId, true);
            jwt.Token = token;
            await _ac.SaveChangesAsync();
        }
        public Task<Jwts> GetById(int id, bool trackChanges = false)
        {
            return _ac.Jwts
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<bool> RevokeByTokenId(int actorId, int tokenId)
        {
            var activeToken = await _ac.Jwts.FirstOrDefaultAsync(u => u.Id == tokenId);
            if (activeToken == null)
                return false;

            activeToken.Deleted = DateTimeOffset.UtcNow;
            activeToken.DeletedById = actorId;
            activeToken.IsDeleted = true;

            await _ac.SaveChangesAsync();

            return true;
        }
    }
}
