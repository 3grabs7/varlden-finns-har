using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.TeacherRegistrationForm;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TeacherRegistrationForm> TeacherRegistrationForms { get; set; }
        public DbSet<ScheduledTimeSpan> ScheduledTimeSpans { get; set; }
    }
}
