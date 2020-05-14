﻿using Microsoft.EntityFrameworkCore;
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
        }

        public DbSet<Identities> Identities { get; set; }

        public DbSet<Jwts> Jwts { get; set; }

        public DbSet<UsersProfiles> UsersProfiles { get; set; }
    }
}
