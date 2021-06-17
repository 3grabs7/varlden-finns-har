using Microsoft.EntityFrameworkCore;

namespace WebApp.Extensions
{
    public static class Extensions
    {
        // Extension for Ef core to clear all entries of a certain type
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
