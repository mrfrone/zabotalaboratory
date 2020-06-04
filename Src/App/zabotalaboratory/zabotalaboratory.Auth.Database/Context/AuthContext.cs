using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Auth.Database.Entities;

namespace zabotalaboratory.Auth.Database.Context
{
    public class AuthContext : DbContext
    {
        public const string SchemaName = "zabota_auth";
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityByDefaultColumns();
            modelBuilder.HasDefaultSchema(SchemaName);

            modelBuilder.Entity<Entities.Roles>(e =>
            {
                e.HasData(new[]
                {
                    new Entities.Roles() { Id = 1, Name = Common.Consts.Roles.Roles.Admin },
                    new Entities.Roles() { Id = 2, Name = Common.Consts.Roles.Roles.Laborant },
                    new Entities.Roles() { Id = 3, Name = Common.Consts.Roles.Roles.Clinic }
                });
            });
        }

        public DbSet<Identities> Identities { get; set; }

        public DbSet<Jwts> Jwts { get; set; }

        public DbSet<UsersProfiles> UsersProfiles { get; set; }

        public DbSet<Entities.Roles> Roles { get; set; }
    }
}
