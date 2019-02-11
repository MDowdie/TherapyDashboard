using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TherapyDashboard.Areas.Identity.Data
{

    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Counselor = "Counselor";
        public const string Intern = "Intern";
        public const string IT = "I.T.";
        public const string Pending = "Pending"; // user role not assigned yet, and needs assigning
        public const string Lockout = "Lockout"; // user no longer employed with therapy institution, prevents user from accessing anything but leaves their current name/records on site intact


        // lists of roles used in many, MANY different locations across the project. hard-coded, I know. must be kept up-to-date.
        public static string[] ToArray = { "Admin", "Counselor", "Intern", "I.T.", "Pending", "Lockout" }; // used in Views to get list of possible roles in foreach scenarios; must be kept up-to-date
        public static string[] Valid = { "Admin", "Counselor", "Intern", "I.T."}; // A list of all arrays, but does not include Lockout or Pending. Is used in IdentityHostingStartup to recognize all roles allowed on the site. If someone's been set to Lockout, they'll be able to log in, but be unable to do anything. Must be kept up-to-date.
        public static string[] CanEditAccounts = { "Admin", "I.T." };
        public static string[] CanModifyAssessmentsAndQuestions = { "Admin", "Counselor" };
        public static string[] CanConductAssessments = { "Admin", "Counselor", "Intern" };
        public static string[] CanGenerateReports = { "Admin", "Counselor" };
    }


    
    //  for further reading: https://stackoverflow.com/questions/51004516/net-core-2-1-identity-get-all-users-with-their-associated-roles/51005445#51005445
    

}