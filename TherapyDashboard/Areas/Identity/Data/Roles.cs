using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TherapyDashboard.Areas.Identity.Data
{

    public static class RoleType
    {
        public const string Admin = "Admin";
        public const string Counselor = "Counselor";
        public const string Intern = "Intern";
        public const string IT = "I.T.";
        public const string Lockout = "Lockout"; // user no longer employed with therapy institution, prevents user from accessing anything but leaves their current name/records on site intact
        public const string Pending = "Pending";

        // lists of roles used in many, MANY different locations across the project. hard-coded, I know. must be kept up-to-date.
        public static string[] ToArray = { "Admin", "Counselor", "Intern", "I.T.", "Lockout" }; // used in Views to get list of possible roles in foreach scenarios; must be kept up-to-date
        public static List<SelectListItem> ToSelectListItems = new List<SelectListItem> // notably, this list and the above array doesn't include Pending. This is because Pending isn't a role that an admin should be able to assign/remove from a user, and this particular list is used ONLY for assigning roles to users.
        {
            new SelectListItem {Value = Admin, Text = Admin},
            new SelectListItem {Value = Counselor, Text = Counselor},
            new SelectListItem {Value = Intern, Text = Intern},
            new SelectListItem {Value = IT, Text = IT},
            new SelectListItem {Value = Lockout, Text = Lockout},
        };

        // arrays for policies. names of policy are same as name of variable at time of writing, but hardcoded strings elsewhere.
        public static string[] AnyValidUser = { "Admin", "Counselor", "Intern", "I.T."}; // A list of all arrays, but does not include Lockout. Is used in IdentityHostingStartup to recognize all roles allowed on the site. If someone's been set to Lockout or Pending, they'll be able to log in, but be unable to do anything. Must be kept up-to-date.
        public static string[] CanEditAccounts = { "Admin", "I.T." };
        public static string[] CanModifyAssessmentsAndQuestions = { "Admin", "Counselor" };
        public static string[] CanConductAssessments = { "Admin", "Counselor", "Intern" };
        public static string[] CanGenerateReports = { "Admin", "Counselor" };

        public static async Task SeedInitialUsers(UserManager<TherapyDashboardUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            //note about first time setup: experienced a one-time, as of yet unreproduced bug.
            // all lines run. admin isn't assigned role despite appropriate line running.
            // bug fixed by manually deleting all existing users and roles and trying again, immediately after first time setup. No change to code.
            // yeah, I dunno either.


            //create role if does not exist
            bool admin_does_exist = await _roleManager.RoleExistsAsync(RoleType.Admin);
            if (!admin_does_exist)
            {
                IdentityRole _Role = new IdentityRole(RoleType.Admin);
                var asdf = await _roleManager.CreateAsync(_Role);
            }
            bool it_does_exist = await _roleManager.RoleExistsAsync(RoleType.IT);
            if (!it_does_exist)
            {
                IdentityRole _Role = new IdentityRole(RoleType.IT);
                var asdf = await _roleManager.CreateAsync(_Role);
            }


            if (_userManager.FindByNameAsync("admin").Result == null)
            {
                TherapyDashboardUser initialAdmin = new TherapyDashboardUser();
                initialAdmin.UserName = "admin";
                IdentityResult result = await _userManager.CreateAsync(initialAdmin, "asdfASDF1234!@#$");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(initialAdmin, RoleType.Admin);
                }
            }

            if (_userManager.FindByNameAsync("superuser").Result == null)
            {
                TherapyDashboardUser initialIT = new TherapyDashboardUser();
                initialIT.UserName = "superuser";
                IdentityResult result = await _userManager.CreateAsync(initialIT, "asdfASDF1234!@#$");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(initialIT, RoleType.IT);
                }
            }
        }

    }


    


    /*
     * Here's the code to be added to the start of any controller's View() methods to redirect to the Change Password field if the user's required to get around to that.
     //if, on next login, the user is required to change their password, redirect them directly to the password change page
            if (User.Identity.IsAuthenticated) // if user logged in
            {
                var CurrentLoggedInUser = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (CurrentLoggedInUser.RequirePasswordResetOnNextLogin)
                {
                    string request = HttpContext.Request.PathBase.ToString() + "/Identity/Account/Manage/ChangePassword";
                    return Redirect(request);
                }
            }
     * 
     * 
     */
    //  for further reading: https://stackoverflow.com/questions/51004516/net-core-2-1-identity-get-all-users-with-their-associated-roles/51005445#51005445
    

}
 