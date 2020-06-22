using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Entities;

namespace zabotalaboratory.Analyses.Database.Context
{
    public class AnalysesContext : DbContext
    {
        public const string SchemaName = "zabota_analyses";

        public AnalysesContext(DbContextOptions<AnalysesContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityByDefaultColumns();
            modelBuilder.HasDefaultSchema(SchemaName);

            modelBuilder.Entity<Gender>(e =>
            {
                e.HasData(new[]
                {
                    new Gender() { Id = 1, Name = "Мужской", ShortName = "M"},
                    new Gender() { Id = 2, Name = "Женский", ShortName = "F" }
                });
            });
        }

        public DbSet<Clinics> Clinics { get; set; }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<LaboratoryAnalyses> LaboratoryAnalyses { get; set; }

        public DbSet<Talons> Talons { get; set; }

        public DbSet<AnalysesResult> AnalysesResult { get; set; }

        public DbSet<AnalysesTypes> AnalysesTypes { get; set; }

        public DbSet<LaboratoryAnalysesTests> LaboratoryAnalysesTests { get; set; }
    }
}
