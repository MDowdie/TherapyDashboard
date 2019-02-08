﻿using System;
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
                    .AddEntityFrameworkStores<TherapyDashboardContext>();
            });
        }
    }
}