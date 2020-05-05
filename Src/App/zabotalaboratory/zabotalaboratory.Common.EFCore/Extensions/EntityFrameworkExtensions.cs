using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace zabotalaboratory.Common.EFCore.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IQueryable<TEntity> HasTracking<TEntity>(this IQueryable<TEntity> source, bool trackChanges) where TEntity : class
        {
            if (trackChanges)
            {
                return source.AsTracking();
            }

            return source.AsNoTracking();
        }
    }
}