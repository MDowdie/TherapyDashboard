using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TherapyDashboard.Areas.Identity.Data;
using TherapyDashboard.Models.Database;

namespace TherapyDashboard.Models
{
    public class TherapyDashboardContext : IdentityDbContext<TherapyDashboardUser>
    {
        public TherapyDashboardContext(DbContextOptions<TherapyDashboardContext> options)
            : base(options)
        {
        }

        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AssessmentEdit> AssessmentEdits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
