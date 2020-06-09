using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Common.Datamodel.Abstractions;

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

        public static IQueryable<TEntity> HasValid<TEntity>(this IQueryable<TEntity> source, bool onlyValid) where TEntity : IValidatable
        {
            if (onlyValid)
            {
                return source.Where(c => c.IsValid);
            }
            return source;
        }
    }
}