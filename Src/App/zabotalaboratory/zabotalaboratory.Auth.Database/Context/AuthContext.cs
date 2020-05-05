using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Auth.Database.Entities;

namespace zabotalaboratory.Auth.Database.Context
{
    public class AuthContext : DbContext
    {
        public const string SchemaName = "zabota_auth";
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        public DbSet<Identities> Identities { get; set; }
        public DbSet<Jwts> Jwts { get; set; }

    }
}
