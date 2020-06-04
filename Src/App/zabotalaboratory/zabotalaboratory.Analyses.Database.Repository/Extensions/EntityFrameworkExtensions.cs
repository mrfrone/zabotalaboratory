using Microsoft.EntityFrameworkCore;
using System.Linq;
using zabotalaboratory.Analyses.Database.Entities;

namespace zabotalaboratory.Analyses.Database.Repository.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IQueryable<TEntity> WithTests<TEntity>(this IQueryable<TEntity> source, bool withTests) where TEntity : AnalysesTypes
        {
            if (withTests)
            {
                return source.Include(a => a.LaboratoryAnalysesTests);
            }
            return source;
        }

        public static IQueryable<TEntity> HasValid<TEntity>(this IQueryable<TEntity> source, bool onlyValid) where TEntity : Entities.Clinics
        {
            if (onlyValid)
            {
                return source.Where(c => c.IsValid);
            }
            return source;
        }
    }
}