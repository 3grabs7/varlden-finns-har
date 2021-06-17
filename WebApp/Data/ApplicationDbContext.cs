using DAL.Registration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegistrationOfInterest> RegistrationOfInterests { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<AvailableTimeSpan> AvailableTimeSpans { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MatchCard> MatchCards { get; set; }
    }
}
