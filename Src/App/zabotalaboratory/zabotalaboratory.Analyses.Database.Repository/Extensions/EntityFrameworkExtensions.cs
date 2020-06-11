using System.Linq;

namespace zabotalaboratory.Analyses.Database.Repository.Extentions
{
    public static class EntityFrameworkExtensions
    {
        public static IQueryable<Entities.LaboratoryAnalyses> HasClinic(this IQueryable<Entities.LaboratoryAnalyses> source, int? clinicId)
        {
            if (clinicId != null)
                return source.Where(a => a.ClinicId == clinicId);
            
            return source;
        }
    }
}