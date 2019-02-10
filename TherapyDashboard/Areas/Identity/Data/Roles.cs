using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TherapyDashboard.Areas.Identity.Data
{

    public static class RoleType
    {
        public const string Admin = "Admin";
        public const string Counselor = "Counselor";
        public const string Intern = "Intern";
        public const string IT = "I.T.";
        public const string Pending = "Pending"; // user role not assigned yet, and needs assigning

        public static string[] ToArray = { "Admin", "Counselor", "Intern", "I.T.", "Pending" };



    }


    
    //  for further reading: https://stackoverflow.com/questions/51004516/net-core-2-1-identity-get-all-users-with-their-associated-roles/51005445#51005445
    

}