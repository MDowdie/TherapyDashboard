using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TherapyDashboard.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TherapyDashboardUser class
    public class TherapyDashboardUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }

        public string FirstTimePassword { get; set; }


        public bool RequirePasswordResetOnNextLogin { get; set; }
    }
}
