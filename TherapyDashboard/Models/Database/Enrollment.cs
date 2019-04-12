using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TherapyDashboard.Models.Database
{
    public class Enrollment
    {

        public int Id { get; set; }

        public string ParticipatingIn { get; set; } // program, such as Outreach, Court Advocacy, etc.

        public List<CFARSAssessment> CFARSAssessments { get; set; }
        public List<PPSRAssessment> PPSRAssessments { get; set; }
        public List<PCLAssessment> PCLAssessments { get; set; }


        public string ClientId { get; set; }

        [ForeignKey("ClientForeignKey")]
        public Client Client { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

    }


    public static class EnrollmentHelper
    {
        public static List<SelectListItem> Options { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "Outreach", Text="Outreach"},
            new SelectListItem {Value = "Court Advocacy", Text="Court Advocacy"},
            new SelectListItem {Value = "IFP Attorneys", Text="IFP Attorneys"},
            new SelectListItem {Value = "COACH", Text="COACH"},
            new SelectListItem {Value = "Rapid Rehousing", Text="Rapid Rehousing"},
            new SelectListItem {Value = "Adult Counseling", Text="Adult Counseling"},
            new SelectListItem {Value = "Children's Counseling", Text="Children's Counseling"},
            new SelectListItem {Value = "HARK", Text="HARK"},
        };
    }
}