using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        //public const string Pending = "Pending";

        // lists of roles used in many, MANY different locations across the project. hard-coded, I know. must be kept up-to-date.
        public static string[] ToArray = { "Admin", "Counselor", "Intern", "I.T.", "Lockout" }; // used in Views to get list of possible roles in foreach scenarios; must be kept up-to-date

        // arrays for policies. names of policy are same as name of variable at time of writing, but hardcoded strings elsewhere.
        public static string[] AnyValidUser = { "Admin", "Counselor", "Intern", "I.T."}; // A list of all arrays, but does not include Lockout. Is used in IdentityHostingStartup to recognize all roles allowed on the site. If someone's been set to Lockout or Pending, they'll be able to log in, but be unable to do anything. Must be kept up-to-date.
        public static string[] CanEditAccounts = { "Admin", "I.T." };
        public static string[] CanModifyAssessmentsAndQuestions = { "Admin", "Counselor" };
        public static string[] CanConductAssessments = { "Admin", "Counselor", "Intern" };
        public static string[] CanGenerateReports = { "Admin", "Counselor" };
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
 