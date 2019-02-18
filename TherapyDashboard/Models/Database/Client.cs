using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TherapyDashboard.Models.Database
{
    public class Client
    {
        [Required]
        [Display(Name="Client ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Display(Name ="Ethnicity")]
        public string Ethnicity { get; set; }

        [Display(Name ="Race")]
        public string Race { get; set; }

        [Display(Name ="Gender")]
        public string Gender { get; set; }


        [Display(Name ="Relationship Status")]
        public string RelationshipStatus { get; set; } // TODO: limit to choices

        
        [Display(Name = "Partner Gender")]
        public string PartnerGender { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Participated in:")]
        public List<Enrollment> Enrollments { get; set; } // to shelters, to programs

    }

    public static class Demographics
    {
        public static string[] RelationshipStatus = {"Married", "Co-habiting", "Dating", "Child-in-Common", "Single" };
        public static string[] Gender = {"Female", "Male", "Other", "Transgender Female", "Transgender Male" };
        public static string[] Race = { "American Indian / Alaskan Native", "Asian", "Black / African-American", "Multi-Racial", "Native Hawaiian / Other Pacific Islander", "Other", "White / Caucasian" };
        public static string[] Ethnicity = { "Haitian", "Hispanic / Latino", "Middle Eastern", "Non-Hispanic / Non-Latino", "Other" };

        public static List<SelectListItem> RelationshipStatuses { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "Married", Text="Married"},
            new SelectListItem {Value = "Co-habiting", Text="Co-habiting"},
            new SelectListItem {Value = "Dating", Text="Dating"},
            new SelectListItem {Value = "Child-in-Common", Text="Child-in-Common"},
            new SelectListItem {Value = "Single", Text="Single"}
        };

        public static List<SelectListItem> Genders { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "Female", Text="Female"},
            new SelectListItem {Value = "Male", Text="Male"},
            new SelectListItem {Value = "Other", Text="Other"},
            new SelectListItem {Value = "Transgender Female", Text="Transgender Female"},
            new SelectListItem {Value = "Transgender Male", Text="Transgender Male"},
        };

        public static List<SelectListItem> Races { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "American Indian / Alaskan Native", Text="American Indian / Alaskan Native"},
            new SelectListItem {Value = "Asian", Text="Asian"},
            new SelectListItem {Value = "Black / African-American", Text="Black / African-American"},
            new SelectListItem {Value = "Multi-Racial", Text="Multi-Racial"},
            new SelectListItem {Value = "Married", Text="Native Hawaiian / Other Pacific Islander"},
            new SelectListItem {Value = "Other", Text="Other"},
            new SelectListItem {Value = "White / Caucasian", Text="White / Caucasian"},
        };

        public static List<SelectListItem> Ethnicities { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "Haitian", Text="Haitian"},
            new SelectListItem {Value = "Hispanic / Latino", Text="Hispanic / Latino"},
            new SelectListItem {Value = "Middle Eastern", Text="Middle Eastern"},
            new SelectListItem {Value = "Non-Hispanic / Non-Latino", Text="Non-Hispanic / Non-Latino"},
            new SelectListItem {Value = "Other", Text="Other"},
        };

    }
}
