﻿using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Auth.Services.Identities;

namespace zabotalaboratory.Analyses.Database.Context
{
    public class AnalysesContext : DbContext
    {
        public const string SchemaName = "zabota_analyses";
        private readonly IIdentityService _identityService;

        public AnalysesContext(DbContextOptions<AnalysesContext> options, IIdentityService identityService) : base(options) 
        {
            _identityService = identityService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityByDefaultColumns();
            modelBuilder.HasDefaultSchema(SchemaName);
                        
            modelBuilder.Entity<Clinics>(e =>
            {
                var subRolesData = _identityService.GetSubRoles().Result;
                e.HasData(subRolesData.Result);
            });
        }

        public DbSet<Clinics> Clinics { get; set; }

        public DbSet<LaboratoryAnalyses> LaboratoryAnalyses { get; set; }

        public DbSet<Talons> Talons { get; set; }

        public DbSet<AnalysesResult> AnalysesResult { get; set; }

        public DbSet<AnalysesTypes> AnalysesTypes { get; set; }

        public DbSet<LaboratoryAnalysesTests> LaboratoryAnalysesTests { get; set; }
    }
}
