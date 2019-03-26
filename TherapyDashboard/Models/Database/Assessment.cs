using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TherapyDashboard.Models.Database
{
    public class Assessment
    {
        public enum Type { CFARS, PPSR, PCL }

        [Required]
        [Display(Name = "Assessment ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Client ID")]
        public string ClientId { get; set; }

        [Required]
        [Display(Name = "Conducted By")]
        public string ConductedBy { get; set; } // TODO: set as foreign key (user id)

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Conducted On")]
        public DateTime ConductedOn { get; set; }

        [Required]
        [Display(Name = "Assessment Type")]
        public Type AssessmentType { get; set; }

        [Required]
        [Display(Name = "Answers")]
        public List<Answer> Answers { get; set; }

        [Required]
        [Display(Name = "Score")]
        public int Score { get; set; } // total score from assessment for client

        [Display(Name = "Edits")]
        public List<AssessmentEdit> Edits { get; set; }

        [Display(Name = "Tagged As")]
        public string Tag { get; set; } // pre-, post-, etc. Optional.


        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
    }

    public class AssessmentEdit
    {
        [Required]
        [Display(Name ="Assessment Edit Id")]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Changed Answers")]
        public List<Answer> ChangedAnswers { get; set; }

        [Required]
        [Display(Name = "Edited By")]
        public string ConductedBy { get; set; } // user who made a change (TODO: foreign key, user id)

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "EditedOn")]
        public DateTime ConductedOn { get; set; } // date of changes

        [Required]
        [Display(Name = "Score")]
        public int Score { get; set; } // score at time of edit


        public int AssessmentId { get; set; }
        public Assessment Assessment { get; set; }


    }

    public class Answer
    {
        [Required]
        [Display(Name ="Answer Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Question Number")]
        public int Number { get; set; } // as in "question #1, question #2," etc.

        [Required]
        [Display(Name = "Response")]
        public int Response { get; set; } // "client's response to question 1" was "6", etc.
    }

    public static class Templates
    {
        public static List<SelectListItem> CFARSList { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="0", Text="NA - Unknown"},
            new SelectListItem{Value="1", Text="1 - No Problem"},
            new SelectListItem{Value="2", Text="2 - Less than Slight"},
            new SelectListItem{Value="3", Text="3 - Slight Problem"},
            new SelectListItem{Value="4", Text="4 - Slight to Moderate" },
            new SelectListItem{Value="5", Text="5 - Moderate Problem" },
            new SelectListItem{Value="6", Text="6 - Moderate to Severe" },
            new SelectListItem{Value="7", Text="7 - Severe Problem"},
            new SelectListItem{Value="8", Text="8 - Severe to Extreme" },
            new SelectListItem{Value="9", Text="9 - Extreme Problem" }
        };

        public static List<SelectListItem> PPSRList { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="1", Text="1 - Almost Never"},
            new SelectListItem{Value="2", Text="2" },
            new SelectListItem{Value="3", Text="3" },
            new SelectListItem{Value="4", Text="4 - Sometimes True" },
            new SelectListItem{Value="5", Text="5" },
            new SelectListItem{Value="6", Text="6" },
            new SelectListItem{Value="7", Text="7 - Almost Always" }
        };

        public static List<SelectListItem> PCLList { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="0", Text="0 - Not at All" },
            new SelectListItem{Value="1", Text="1 - A Little Bit"},
            new SelectListItem{Value="2", Text="2 - Moderately" },
            new SelectListItem{Value="3", Text="3 - Quite a Bit" },
            new SelectListItem{Value="4", Text="4 - Extremely" }
        };
    }
}