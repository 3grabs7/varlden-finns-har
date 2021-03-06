using DAL.Matching;
using DAL.Registration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegistrationOfInterest> RegistrationOfInterests { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<RegistrationSchedule> AvailableTimeSpans { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MatchCard> MatchCards { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
