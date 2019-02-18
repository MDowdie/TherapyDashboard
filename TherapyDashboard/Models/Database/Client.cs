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

        
        public string Ethnicity { get; set; }

        public string Race { get; set; }

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
    }
}
