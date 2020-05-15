using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Auth.Database.Entities;

namespace zabotalaboratory.Analyses.Database.Context
{
    public class AuthContext : DbContext
    {
        public const string SchemaName = "zabota_auth";
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityByDefaultColumns();
            modelBuilder.HasDefaultSchema(SchemaName);

            modelBuilder.Entity<Roles>(e =>
            {
                e.HasData(new[]
                {
                    new Roles() { Id = 1, Name="Администратор" },
                    new Roles() { Id = 2, Name="Лаборант" },
                    new Roles() { Id = 3, Name="Поликлиника" }
                });
            });

            modelBuilder.Entity<SubRoles>(e =>
            {
                e.HasData(new[]
                {
                    new SubRoles() { Id = 1, Name="Все" }
                });
            });
        }

        public DbSet<Identities> Identities { get; set; }

        public DbSet<Jwts> Jwts { get; set; }

        public DbSet<UsersProfiles> UsersProfiles { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<SubRoles> SubRoles { get; set; }
    }
}
