using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TherapyDashboard.Areas.Identity.Data;
using TherapyDashboard.Models;

[assembly: HostingStartup(typeof(TherapyDashboard.Areas.Identity.IdentityHostingStartup))]
namespace TherapyDashboard.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TherapyDashboardContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TherapyDashboardContextConnection")));

                services.AddDefaultIdentity<TherapyDashboardUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TherapyDashboardContext>();

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("AnyValidUser", policy => policy.RequireRole(RoleType.AnyValidUser));
                    options.AddPolicy("CanEditAccounts", policy => policy.RequireRole(RoleType.CanEditAccounts));
                    options.AddPolicy("CanModifyAssessments", policy => policy.RequireRole(RoleType.CanModifyAssessmentsAndQuestions));
                    options.AddPolicy("CanConductAssessments", policy => policy.RequireRole(RoleType.CanConductAssessments));
                    options.AddPolicy("CanGenerateReports", policy => policy.RequireRole(RoleType.CanGenerateReports));
                });
            });
        }
    }
}