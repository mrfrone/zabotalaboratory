using System.Linq;
using zabotalaboratory.Auth.Database.Entities;

namespace zabotalaboratory.Auth.Database.Repository.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IQueryable<TEntity> HasValid<TEntity>(this IQueryable<TEntity> source, bool onlyValid) where TEntity : SubRoles
        {
            if (onlyValid)
            {
                return source.Where(p => p.IsValid == true);
            }

            return source;
        }
    }
}