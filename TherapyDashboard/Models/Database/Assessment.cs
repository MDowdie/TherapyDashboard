using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TherapyDashboard.Models.Database
{
    public class CFARSAssessment
    {
        public int Id { get; set; }
        public string ClientID { get; set; }
        public Client Client { get; set; }
        public string UserId { get; set; }
        public DateTime ConductDate { get; set; }
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        public int ParentAssessmentID { get; set; } // if this assessment is an edit, then what's the original?

        public int Score { // sum of all questions' values
            get {
                int output = 0;
                output += Subscale1Score;
                output += Subscale2Score;
                output += Subscale3Score;
                output += Subscale4Score;
                output += Subscale5Score;
                output += Subscale6Score;
                output += Subscale7Score;
                output += Subscale8Score;
                output += Subscale9Score;
                return output;
            }
        }

        #region questions and answers
        // subscale 1: hyperactivity
        public int Subscale1Score {
            get {
                int output = 0;
                output += Answer1;
                output += Answer2;
                output += Answer3;
                output += Answer4;
                output += Answer5;
                output += Answer6;
                output += Answer7;
                output += Answer8;
                output += Answer9;
                output += Answer10;
                return output;
            }
        }
        
        public int Answer1 { get; set; }
        
        public int Answer2 { get; set; }
        
        public int Answer3 { get; set; }
        
        public int Answer4 { get; set; }
        
        public int Answer5 { get; set; }
        
        public int Answer6 { get; set; }
        
        public int Answer7 { get; set; }
        
        public int Answer8 { get; set; }
        
        public int Answer9 { get; set; }
        
        public int Answer10 { get; set; }

        // subscale 2: work or school
        public int Subscale2Score {
            get {
                int output = 0;
                output += Answer11;
                output += Answer12;
                output += Answer13;
                output += Answer14;
                output += Answer15;
                output += Answer16;
                output += Answer17;
                output += Answer18;
                output += Answer19;
                output += Answer20;
                output += Answer21;
                output += Answer22;
                return output;
            }
        }
        
        public int Answer11 { get; set; }
        
        public int Answer12 { get; set; }
        
        public int Answer13 { get; set; }
        
        public int Answer14 { get; set; }
        
        public int Answer15 { get; set; }
        
        public int Answer16 { get; set; }
        
        public int Answer17 { get; set; }
        
        public int Answer18 { get; set; }
        
        public int Answer19 { get; set; }
        
        public int Answer20 { get; set; }
        
        public int Answer21 { get; set; }
        
        public int Answer22 { get; set; }

        // subscale 3: interpersonal relationships
        public int Subscale3Score {
            get {
                int output = 0;
                output += Answer23;
                output += Answer24;
                output += Answer25;
                output += Answer26;
                return output;
            }
        }
        
        public int Answer23 { get; set; }
        
        public int Answer24 { get; set; }
        
        public int Answer25 { get; set; }
        
        public int Answer26 { get; set; }

        // subscale 4: cognitive performance
        public int Subscale4Score {
            get {
                int output = 0;
                output += Answer27;
                output += Answer28;
                output += Answer29;
                output += Answer30;
                output += Answer31;
                output += Answer32;
                output += Answer33;
                return output;
            }
        }
        
        public int Answer27 { get; set; }
        
        public int Answer28 { get; set; }
        
        public int Answer29 { get; set; }
        
        public int Answer30 { get; set; }
        
        public int Answer31 { get; set; }
        
        public int Answer32 { get; set; }
        
        public int Answer33 { get; set; }

        //subscale 5: behavior in "home" setting
        public int Subscale5Score {
            get {
                int output = 0;
                output += Answer34;
                output += Answer35;
                output += Answer36;
                output += Answer37;
                output += Answer38;
                return output;
            }
        }
        
        public int Answer34 { get; set; }
        
        public int Answer35 { get; set; }
        
        public int Answer36 { get; set; }
        
        public int Answer37 { get; set; }
        
        public int Answer38 { get; set; }


        //subscale 6: danger to others
        public int Subscale6Score {
            get {
                int output = 0;
                output += Answer39;
                output += Answer40;
                output += Answer41;
                output += Answer42;
                output += Answer43;
                output += Answer44;
                output += Answer45;
                output += Answer46;
                output += Answer47;
                output += Answer48;
                output += Answer49;
                return output;
            }
        }
        
        public int Answer39 { get; set; }
        
        public int Answer40 { get; set; }
        
        public int Answer41 { get; set; }
        
        public int Answer42 { get; set; }
        
        public int Answer43 { get; set; }
        
        public int Answer44 { get; set; }
        
        public int Answer45 { get; set; }
        
        public int Answer46 { get; set; }
        
        public int Answer47 { get; set; }
        
        public int Answer48 { get; set; }
        
        public int Answer49 { get; set; }


        //subscale 7: anxiety
        public int Subscale7Score {
            get {
                int output = 0;
                output += Answer50;
                output += Answer51;
                output += Answer52;
                output += Answer53;
                output += Answer54;
                output += Answer55;
                output += Answer56;
                return output;
            }
        }
        
        public int Answer50 { get; set; }
        
        public int Answer51 { get; set; }
        
        public int Answer52 { get; set; }
        
        public int Answer53 { get; set; }
        
        public int Answer54 { get; set; }
        
        public int Answer55 { get; set; }
        
        public int Answer56 { get; set; }

        //subscale 8: traumatic stress
        public int Subscale8Score {
            get {
                int output = 0;
                output += Answer57;
                output += Answer58;
                output += Answer59;
                output += Answer60;
                output += Answer61;
                output += Answer62;
                output += Answer63;
                output += Answer64;
                return output;
            }
        }
        
        public int Answer57 { get; set; }
        
        public int Answer58 { get; set; }
        
        public int Answer59 { get; set; }
        
        public int Answer60 { get; set; }
        
        public int Answer61 { get; set; }
        
        public int Answer62 { get; set; }
        
        public int Answer63 { get; set; }
        
        public int Answer64 { get; set; }

        //subscale 9: depression
        public int Subscale9Score {
            get {
                int output = 0;
                output += Answer65;
                output += Answer66;
                output += Answer67;
                output += Answer68;
                output += Answer69;
                output += Answer70;
                output += Answer71;
                output += Answer72;
                return output;
            }
        }
        
        public int Answer65 { get; set; }
        
        public int Answer66 { get; set; }
        
        public int Answer67 { get; set; }
        
        public int Answer68 { get; set; }
        
        public int Answer69 { get; set; }
        
        public int Answer70 { get; set; }
        
        public int Answer71 { get; set; }
        
        public int Answer72 { get; set; }
        #endregion
    }

    public class PPSRAssessment
    {
        public int Id { get; set; }
        [HiddenInput]
        public string ClientID { get; set; }
        [HiddenInput]
        public Client Client { get; set; }
        [HiddenInput]
        public string UserId { get; set; }
        [HiddenInput]
        public DateTime ConductDate { get; set; }
        [HiddenInput]
        public int EnrollmentID { get; set; }
        [HiddenInput]
        public Enrollment Enrollment { get; set; }
        [HiddenInput]
        public int ParentAssessmentID { get; set; } // if this assessment is an edit, then what's the original?

        public int Score { // sum of all questions, some "negatively coded" per instructions
            get {
                int output = 0;
                output += Answer1;
                output += Answer2;
                output -= Answer3;
                output += Answer4;
                output += Answer5;
                output -= Answer6;
                output += Answer7;
                output += Answer8;
                output -= Answer9;
                output -= Answer10;
                output -= Answer11;
                output += Answer12;
                output += Answer13;
                output -= Answer14;
                output -= Answer15;
                output -= Answer16;
                output += Answer17;
                output -= Answer18;
                output += Answer19;
                output -= Answer20;
                output -= Answer21;
                output += Answer22;
                output -= Answer23;
                output -= Answer24;
                output += Answer25;
                output -= Answer26;
                output += Answer27;
                output += Answer28;
                return output;
            }
        }

        #region subscales
        public int SubscaleAScore { // perceptions of power and competence
            get {
                int output = 0;
                output += Answer1;
                output -= Answer10;
                output += Answer13;
                output -= Answer15;
                output -= Answer16;
                output += Answer19;
                output -= Answer20;
                output += Answer28;
                return output;
            }
        }
        public int SubscaleBScore { // self-nurturance and resource access
            get {
                int output = 0;
                output += Answer4;
                output -= Answer23;
                output -= Answer24;
                return output;
            }
        }
        public int SubscaleCScore { // interpersonal assertiveness
            get {
                int output = 0;
                output -= Answer3;
                output += Answer7;
                output -= Answer11;
                output -= Answer14;
                output += Answer22;
                return output;
            }
        }
        public int SubscaleDScore { // awareness of cultural discrimination
            get {
                int output = 0;
                output += Answer5;
                output += Answer8;
                output += Answer27;
                return output;
            }
        }
        public int SubscaleEScore { // expression of anger and confrontation
            get {
                int output = 0;
                output -= Answer6;
                output -= Answer21;
                output -= Answer26;
                return output;
            }
        }
        public int SubscaleFScore { // autonomy
            get {
                int output = 0;
                output += Answer2;
                output += Answer12;
                output += Answer17;
                return output;
            }
        }
        public int SubscaleGScore { // personal strength and social activisim
            get {
                int output = 0;
                output -= Answer9;
                output -= Answer18;
                output += Answer25;
                return output;
            }
        }

        #endregion
        #region questions and answers
        //// questions and answers

        public int Answer1 { get; set; }
        
        public int Answer2 { get; set; }
        
        public int Answer3 { get; set; }
        
        public int Answer4 { get; set; }
        
        public int Answer5 { get; set; }
        
        public int Answer6 { get; set; }
        
        public int Answer7 { get; set; }
        
        public int Answer8 { get; set; }
        
        public int Answer9 { get; set; }
        
        public int Answer10 { get; set; }
        
        public int Answer11 { get; set; }
        
        public int Answer12 { get; set; }
        
        public int Answer13 { get; set; }
        
        public int Answer14 { get; set; }
        
        public int Answer15 { get; set; }
        
        public int Answer16 { get; set; }
        
        public int Answer17 { get; set; }
        
        public int Answer18 { get; set; }
        
        public int Answer19 { get; set; }
        
        public int Answer20 { get; set; }
        
        public int Answer21 { get; set; }
        
        public int Answer22 { get; set; }
        
        public int Answer23 { get; set; }
        
        public int Answer24 { get; set; }
        
        public int Answer25 { get; set; }
        
        public int Answer26 { get; set; }
        
        public int Answer27 { get; set; }
        
        public int Answer28 { get; set; }
        #endregion
    }

    public class PCLAssessment
    {
        public int Id { get; set; }
        public string ClientID { get; set; }
        public Client Client { get; set; }
        public string UserId { get; set; }
        public DateTime ConductDate { get; set; }
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        public int ParentAssessmentID { get; set; } // if this assessment is an edit, then what's the original?

        public int Score { // sum of all question values. score of 33+ seems to suggest PTSD.
            get {
                int output = 0;
                output += Answer1;
                output += Answer2;
                output += Answer3;
                output += Answer4;
                output += Answer5;
                output += Answer6;
                output += Answer7;
                output += Answer8;
                output += Answer9;
                output += Answer10;
                output += Answer11;
                output += Answer12;
                output += Answer13;
                output += Answer14;
                output += Answer15;
                output += Answer16;
                output += Answer17;
                output += Answer18;
                output += Answer19;
                output += Answer20;
                return output;
            }
        }

        #region questions and answers

        public int Answer1 { get; set; }
        
        public int Answer2 { get; set; }
        
        public int Answer3 { get; set; }
        
        public int Answer4 { get; set; }
        
        public int Answer5 { get; set; }
        
        public int Answer6 { get; set; }
        
        public int Answer7 { get; set; }
        
        public int Answer8 { get; set; }
        
        public int Answer9 { get; set; }
        
        public int Answer10 { get; set; }
        
        public int Answer11 { get; set; }
        
        public int Answer12 { get; set; }
        
        public int Answer13 { get; set; }
        
        public int Answer14 { get; set; }
        
        public int Answer15 { get; set; }
        
        public int Answer16 { get; set; }
        
        public int Answer17 { get; set; }
        
        public int Answer18 { get; set; }
        
        public int Answer19 { get; set; }
        
        public int Answer20 { get; set; }
        #endregion questions and answers
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