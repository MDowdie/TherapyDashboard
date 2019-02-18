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
        public string ClientId { get; set; } // TODO: set as foreign key (client id)

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

        [Required]
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
        public string ConductedBy { get; set; } // user who made a change

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
}