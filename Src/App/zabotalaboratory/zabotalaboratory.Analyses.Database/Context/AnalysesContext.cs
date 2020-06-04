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
        }

        public DbSet<Clinics> Clinics { get; set; }

        public DbSet<LaboratoryAnalyses> LaboratoryAnalyses { get; set; }

        public DbSet<Talons> Talons { get; set; }

        public DbSet<AnalysesResult> AnalysesResult { get; set; }

        public DbSet<AnalysesTypes> AnalysesTypes { get; set; }

        public DbSet<LaboratoryAnalysesTests> LaboratoryAnalysesTests { get; set; }
    }
}
