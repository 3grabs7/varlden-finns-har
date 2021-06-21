using Microsoft.EntityFrameworkCore;

namespace WebApp.Extensions
{
    public static class EfCoreExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
