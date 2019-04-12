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
        [HiddenInput]
        public string ClientID { get; set; }
        public Client Client { get; set; }
        [HiddenInput]
        public string UserId { get; set; }
        [HiddenInput]
        public DateTime ConductDate { get; set; }
        [HiddenInput]
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        [HiddenInput]
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
                output += answer1;
                output += answer2;
                output += answer3;
                output += answer4;
                output += answer5;
                output += answer6;
                output += answer7;
                output += answer8;
                output += answer9;
                output += answer10;
                return output;
            }
        }
        
        private int answer1 { get; set; }
        public string Answer1 { get { return answer1.ToString(); } set { answer1 = Int32.Parse(value); } }

        private int answer2 { get; set; }
        public string Answer2 { get { return answer2.ToString(); } set { answer2 = Int32.Parse(value); } }

        private int answer3 { get; set; }
        public string Answer3 { get { return answer3.ToString(); } set { answer3 = Int32.Parse(value); } }

        private int answer4 { get; set; }
        public string Answer4 { get { return answer4.ToString(); } set { answer4 = Int32.Parse(value); } }

        private int answer5 { get; set; }
        public string Answer5 { get { return answer5.ToString(); } set { answer5 = Int32.Parse(value); } }

        private int answer6 { get; set; }
        public string Answer6 { get { return answer6.ToString(); } set { answer6 = Int32.Parse(value); } }

        private int answer7 { get; set; }
        public string Answer7 { get { return answer7.ToString(); } set { answer7 = Int32.Parse(value); } }

        private int answer8 { get; set; }
        public string Answer8 { get { return answer8.ToString(); } set { answer8 = Int32.Parse(value); } }

        private int answer9 { get; set; }
        public string Answer9 { get { return answer9.ToString(); } set { answer9 = Int32.Parse(value); } }

        private int answer10 { get; set; }
        public string Answer10 { get { return answer10.ToString(); } set { answer10 = Int32.Parse(value); } }

        // subscale 2: work or school
        public int Subscale2Score {
            get {
                int output = 0;
                output += answer11;
                output += answer12;
                output += answer13;
                output += answer14;
                output += answer15;
                output += answer16;
                output += answer17;
                output += answer18;
                output += answer19;
                output += answer20;
                output += answer21;
                output += answer22;
                return output;
            }
        }
        
        private int answer11 { get; set; }
        public string Answer11 { get { return answer11.ToString(); } set { answer11 = Int32.Parse(value); } }

        private int answer12 { get; set; }
        public string Answer12 { get { return answer12.ToString(); } set { answer12 = Int32.Parse(value); } }

        private int answer13 { get; set; }
        public string Answer13 { get { return answer13.ToString(); } set { answer13 = Int32.Parse(value); } }

        private int answer14 { get; set; }
        public string Answer14 { get { return answer14.ToString(); } set { answer14 = Int32.Parse(value); } }

        private int answer15 { get; set; }
        public string Answer15 { get { return answer15.ToString(); } set { answer15 = Int32.Parse(value); } }


        private int answer16 { get; set; }
        public string Answer16 { get { return answer16.ToString(); } set { answer16 = Int32.Parse(value); } }

        private int answer17 { get; set; }
        public string Answer17 { get { return answer17.ToString(); } set { answer17 = Int32.Parse(value); } }

        private int answer18 { get; set; }
        public string Answer18 { get { return answer18.ToString(); } set { answer18 = Int32.Parse(value); } }


        private int answer19 { get; set; }
        public string Answer19 { get { return answer19.ToString(); } set { answer19 = Int32.Parse(value); } }


        private int answer20 { get; set; }
        public string Answer20 { get { return answer20.ToString(); } set { answer20 = Int32.Parse(value); } }

        private int answer21 { get; set; }
        public string Answer21 { get { return answer21.ToString(); } set { answer21 = Int32.Parse(value); } }

        private int answer22 { get; set; }
        public string Answer22 { get { return answer22.ToString(); } set { answer22 = Int32.Parse(value); } }

        // subscale 3: interpersonal relationships
        public int Subscale3Score {
            get {
                int output = 0;
                output += answer23;
                output += answer24;
                output += answer25;
                output += answer26;
                return output;
            }
        }
        
        private int answer23 { get; set; }
        public string Answer23 { get { return answer23.ToString(); } set { answer23 = Int32.Parse(value); } }

        private int answer24 { get; set; }
        public string Answer24 { get { return answer24.ToString(); } set { answer24 = Int32.Parse(value); } }

        private int answer25 { get; set; }
        public string Answer25 { get { return answer25.ToString(); } set { answer25 = Int32.Parse(value); } }

        private int answer26 { get; set; }
        public string Answer26 { get { return answer26.ToString(); } set { answer26 = Int32.Parse(value); } }

        // subscale 4: cognitive performance
        public int Subscale4Score {
            get {
                int output = 0;
                output += answer27;
                output += answer28;
                output += answer29;
                output += answer30;
                output += answer31;
                output += answer32;
                output += answer33;
                return output;
            }
        }
        
        private int answer27 { get; set; }
        public string Answer27 { get { return answer27.ToString(); } set { answer27 = Int32.Parse(value); } }

        private int answer28 { get; set; }
        public string Answer28 { get { return answer28.ToString(); } set { answer28 = Int32.Parse(value); } }

        private int answer29 { get; set; }
        public string Answer29 { get { return answer29.ToString(); } set { answer29 = Int32.Parse(value); } }

        private int answer30 { get; set; }
        public string Answer30 { get { return answer30.ToString(); } set { answer30 = Int32.Parse(value); } }

        private int answer31 { get; set; }
        public string Answer31 { get { return answer31.ToString(); } set { answer31 = Int32.Parse(value); } }

        private int answer32 { get; set; }
        public string Answer32 { get { return answer32.ToString(); } set { answer32 = Int32.Parse(value); } }

        private int answer33 { get; set; }
        public string Answer33 { get { return answer33.ToString(); } set { answer33 = Int32.Parse(value); } }

        //subscale 5: behavior in "home" setting
        public int Subscale5Score {
            get {
                int output = 0;
                output += answer34;
                output += answer35;
                output += answer36;
                output += answer37;
                output += answer38;
                return output;
            }
        }
        
        private int answer34 { get; set; }
        public string Answer34 { get { return answer34.ToString(); } set { answer34 = Int32.Parse(value); } }

        private int answer35 { get; set; }
        public string Answer35 { get { return answer35.ToString(); } set { answer35 = Int32.Parse(value); } }

        private int answer36 { get; set; }
        public string Answer36 { get { return answer36.ToString(); } set { answer36 = Int32.Parse(value); } }

        private int answer37 { get; set; }
        public string Answer37 { get { return answer37.ToString(); } set { answer37 = Int32.Parse(value); } }

        private int answer38 { get; set; }
        public string Answer38 { get { return answer38.ToString(); } set { answer38 = Int32.Parse(value); } }


        //subscale 6: danger to others
        public int Subscale6Score {
            get {
                int output = 0;
                output += answer39;
                output += answer40;
                output += answer41;
                output += answer42;
                output += answer43;
                output += answer44;
                output += answer45;
                output += answer46;
                output += answer47;
                output += answer48;
                output += answer49;
                return output;
            }
        }
        
        private int answer39 { get; set; }
        public string Answer39 { get { return answer39.ToString(); } set { answer39 = Int32.Parse(value); } }

        private int answer40 { get; set; }
        public string Answer40 { get { return answer40.ToString(); } set { answer40 = Int32.Parse(value); } }

        private int answer41 { get; set; }
        public string Answer41 { get { return answer41.ToString(); } set { answer41 = Int32.Parse(value); } }

        private int answer42 { get; set; }
        public string Answer42 { get { return answer42.ToString(); } set { answer42 = Int32.Parse(value); } }

        private int answer43 { get; set; }
        public string Answer43 { get { return answer43.ToString(); } set { answer43 = Int32.Parse(value); } }

        private int answer44 { get; set; }
        public string Answer44 { get { return answer44.ToString(); } set { answer44 = Int32.Parse(value); } }

        private int answer45 { get; set; }
        public string Answer45 { get { return answer45.ToString(); } set { answer45 = Int32.Parse(value); } }

        private int answer46 { get; set; }
        public string Answer46 { get { return answer46.ToString(); } set { answer46 = Int32.Parse(value); } }

        private int answer47 { get; set; }
        public string Answer47 { get { return answer47.ToString(); } set { answer47 = Int32.Parse(value); } }

        private int answer48 { get; set; }
        public string Answer48 { get { return answer48.ToString(); } set { answer48 = Int32.Parse(value); } }

        private int answer49 { get; set; }
        public string Answer49 { get { return answer49.ToString(); } set { answer49 = Int32.Parse(value); } }


        //subscale 7: anxiety
        public int Subscale7Score {
            get {
                int output = 0;
                output += answer50;
                output += answer51;
                output += answer52;
                output += answer53;
                output += answer54;
                output += answer55;
                output += answer56;
                return output;
            }
        }
        
        private int answer50 { get; set; }
        public string Answer50 { get { return answer50.ToString(); } set { answer50 = Int32.Parse(value); } }

        private int answer51 { get; set; }
        public string Answer51 { get { return answer51.ToString(); } set { answer51 = Int32.Parse(value); } }

        private int answer52 { get; set; }
        public string Answer52 { get { return answer52.ToString(); } set { answer52 = Int32.Parse(value); } }

        private int answer53 { get; set; }
        public string Answer53 { get { return answer53.ToString(); } set { answer53 = Int32.Parse(value); } }

        private int answer54 { get; set; }
        public string Answer54 { get { return answer54.ToString(); } set { answer54 = Int32.Parse(value); } }

        private int answer55 { get; set; }
        public string Answer55 { get { return answer55.ToString(); } set { answer55 = Int32.Parse(value); } }

        private int answer56 { get; set; }
        public string Answer56 { get { return answer56.ToString(); } set { answer56 = Int32.Parse(value); } }

        //subscale 8: traumatic stress
        public int Subscale8Score {
            get {
                int output = 0;
                output += answer57;
                output += answer58;
                output += answer59;
                output += answer60;
                output += answer61;
                output += answer62;
                output += answer63;
                output += answer64;
                return output;
            }
        }
        
        private int answer57 { get; set; }
        public string Answer57 { get { return answer57.ToString(); } set { answer57 = Int32.Parse(value); } }

        private int answer58 { get; set; }
        public string Answer58 { get { return answer58.ToString(); } set { answer58 = Int32.Parse(value); } }

        private int answer59 { get; set; }
        public string Answer59 { get { return answer59.ToString(); } set { answer59 = Int32.Parse(value); } }

        private int answer60 { get; set; }
        public string Answer60 { get { return answer60.ToString(); } set { answer60 = Int32.Parse(value); } }

        private int answer61 { get; set; }
        public string Answer61 { get { return answer61.ToString(); } set { answer61 = Int32.Parse(value); } }

        private int answer62 { get; set; }
        public string Answer62 { get { return answer62.ToString(); } set { answer62 = Int32.Parse(value); } }

        private int answer63 { get; set; }
        public string Answer63 { get { return answer63.ToString(); } set { answer63 = Int32.Parse(value); } }

        private int answer64 { get; set; }
        public string Answer64 { get { return answer64.ToString(); } set { answer64 = Int32.Parse(value); } }

        //subscale 9: depression
        public int Subscale9Score {
            get {
                int output = 0;
                output += answer65;
                output += answer66;
                output += answer67;
                output += answer68;
                output += answer69;
                output += answer70;
                output += answer71;
                output += answer72;
                return output;
            }
        }
        
        private int answer65 { get; set; }
        public string Answer65 { get { return answer65.ToString(); } set { answer65 = Int32.Parse(value); } }

        private int answer66 { get; set; }
        public string Answer66 { get { return answer66.ToString(); } set { answer66 = Int32.Parse(value); } }

        private int answer67 { get; set; }
        public string Answer67 { get { return answer67.ToString(); } set { answer67 = Int32.Parse(value); } }

        private int answer68 { get; set; }
        public string Answer68 { get { return answer68.ToString(); } set { answer68 = Int32.Parse(value); } }

        private int answer69 { get; set; }
        public string Answer69 { get { return answer69.ToString(); } set { answer69 = Int32.Parse(value); } }

        private int answer70 { get; set; }
        public string Answer70 { get { return answer70.ToString(); } set { answer70 = Int32.Parse(value); } }

        private int answer71 { get; set; }
        public string Answer71 { get { return answer71.ToString(); } set { answer71 = Int32.Parse(value); } }

        private int answer72 { get; set; }
        public string Answer72 { get { return answer72.ToString(); } set { answer72 = Int32.Parse(value); } }
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
                output += answer1;
                output += answer2;
                output -= answer3;
                output += answer4;
                output += answer5;
                output -= answer6;
                output += answer7;
                output += answer8;
                output -= answer9;
                output -= answer10;
                output -= answer11;
                output += answer12;
                output += answer13;
                output -= answer14;
                output -= answer15;
                output -= answer16;
                output += answer17;
                output -= answer18;
                output += answer19;
                output -= answer20;
                output -= answer21;
                output += answer22;
                output -= answer23;
                output -= answer24;
                output += answer25;
                output -= answer26;
                output += answer27;
                output += answer28;
                return output;
            }
        }

        #region subscales
        public int SubscaleAScore { // perceptions of power and competence
            get {
                int output = 0;
                output += answer1;
                output -= answer10;
                output += answer13;
                output -= answer15;
                output -= answer16;
                output += answer19;
                output -= answer20;
                output += answer28;
                return output;
            }
        }
        public int SubscaleBScore { // self-nurturance and resource access
            get {
                int output = 0;
                output += answer4;
                output -= answer23;
                output -= answer24;
                return output;
            }
        }
        public int SubscaleCScore { // interpersonal assertiveness
            get {
                int output = 0;
                output -= answer3;
                output += answer7;
                output -= answer11;
                output -= answer14;
                output += answer22;
                return output;
            }
        }
        public int SubscaleDScore { // awareness of cultural discrimination
            get {
                int output = 0;
                output += answer5;
                output += answer8;
                output += answer27;
                return output;
            }
        }
        public int SubscaleEScore { // expression of anger and confrontation
            get {
                int output = 0;
                output -= answer6;
                output -= answer21;
                output -= answer26;
                return output;
            }
        }
        public int SubscaleFScore { // autonomy
            get {
                int output = 0;
                output += answer2;
                output += answer12;
                output += answer17;
                return output;
            }
        }
        public int SubscaleGScore { // personal strength and social activisim
            get {
                int output = 0;
                output -= answer9;
                output -= answer18;
                output += answer25;
                return output;
            }
        }

        #endregion
        #region questions and answers
        //// questions and answers

        private int answer1 { get; set; }
        public string Answer1 { get { return answer1.ToString(); } set { answer1 = Int32.Parse(value); } }

        private int answer2 { get; set; }
        public string Answer2 { get { return answer2.ToString(); } set { answer2 = Int32.Parse(value); } }

        private int answer3 { get; set; }
        public string Answer3 { get { return answer3.ToString(); } set { answer3 = Int32.Parse(value); } }

        private int answer4 { get; set; }
        public string Answer4 { get { return answer4.ToString(); } set { answer4 = Int32.Parse(value); } }

        private int answer5 { get; set; }
        public string Answer5 { get { return answer5.ToString(); } set { answer5 = Int32.Parse(value); } }

        private int answer6 { get; set; }
        public string Answer6 { get { return answer6.ToString(); } set { answer6 = Int32.Parse(value); } }

        private int answer7 { get; set; }
        public string Answer7 { get { return answer7.ToString(); } set { answer7 = Int32.Parse(value); } }

        private int answer8 { get; set; }
        public string Answer8 { get { return answer8.ToString(); } set { answer8 = Int32.Parse(value); } }

        private int answer9 { get; set; }
        public string Answer9 { get { return answer9.ToString(); } set { answer9 = Int32.Parse(value); } }

        private int answer10 { get; set; }
        public string Answer10 { get { return answer10.ToString(); } set { answer10 = Int32.Parse(value); } }

        private int answer11 { get; set; }
        public string Answer11 { get { return answer11.ToString(); } set { answer11 = Int32.Parse(value); } }

        private int answer12 { get; set; }
        public string Answer12 { get { return answer12.ToString(); } set { answer12 = Int32.Parse(value); } }

        private int answer13 { get; set; }
        public string Answer13 { get { return answer13.ToString(); } set { answer13 = Int32.Parse(value); } }

        private int answer14 { get; set; }
        public string Answer14 { get { return answer14.ToString(); } set { answer14 = Int32.Parse(value); } }

        private int answer15 { get; set; }
        public string Answer15 { get { return answer15.ToString(); } set { answer15 = Int32.Parse(value); } }

        private int answer16 { get; set; }
        public string Answer16 { get { return answer16.ToString(); } set { answer16 = Int32.Parse(value); } }

        private int answer17 { get; set; }
        public string Answer17 { get { return answer17.ToString(); } set { answer17 = Int32.Parse(value); } }

        private int answer18 { get; set; }
        public string Answer18 { get { return answer18.ToString(); } set { answer18 = Int32.Parse(value); } }

        private int answer19 { get; set; }
        public string Answer19 { get { return answer19.ToString(); } set { answer19 = Int32.Parse(value); } }

        private int answer20 { get; set; }
        public string Answer20 { get { return answer20.ToString(); } set { answer20 = Int32.Parse(value); } }

        private int answer21 { get; set; }
        public string Answer21 { get { return answer21.ToString(); } set { answer21 = Int32.Parse(value); } }

        private int answer22 { get; set; }
        public string Answer22 { get { return answer22.ToString(); } set { answer22 = Int32.Parse(value); } }

        private int answer23 { get; set; }
        public string Answer23 { get { return answer23.ToString(); } set { answer23 = Int32.Parse(value); } }

        private int answer24 { get; set; }
        public string Answer24 { get { return answer24.ToString(); } set { answer24 = Int32.Parse(value); } }

        private int answer25 { get; set; }
        public string Answer25 { get { return answer25.ToString(); } set { answer25 = Int32.Parse(value); } }

        private int answer26 { get; set; }
        public string Answer26 { get { return answer26.ToString(); } set { answer26 = Int32.Parse(value); } }

        private int answer27 { get; set; }
        public string Answer27 { get { return answer27.ToString(); } set { answer27 = Int32.Parse(value); } }

        private int answer28 { get; set; }
        public string Answer28 { get { return answer28.ToString(); } set { answer28 = Int32.Parse(value); } }
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
                output += answer1;
                output += answer2;
                output += answer3;
                output += answer4;
                output += answer5;
                output += answer6;
                output += answer7;
                output += answer8;
                output += answer9;
                output += answer10;
                output += answer11;
                output += answer12;
                output += answer13;
                output += answer14;
                output += answer15;
                output += answer16;
                output += answer17;
                output += answer18;
                output += answer19;
                output += answer20;
                return output;
            }
        }

        #region questions and answers

        private int answer1 { get; set; }
        public string Answer1 { get { return answer1.ToString(); } set { answer1 = Int32.Parse(value); } }
        
        private int answer2 { get; set; }
        public string Answer2 { get { return answer2.ToString(); } set { answer2 = Int32.Parse(value); } }

        private int answer3 { get; set; }
        public string Answer3 { get { return answer3.ToString(); } set { answer3 = Int32.Parse(value); } }

        private int answer4 { get; set; }
        public string Answer4 { get { return answer4.ToString(); } set { answer4 = Int32.Parse(value); } }

        private int answer5 { get; set; }
        public string Answer5 { get { return answer5.ToString(); } set { answer5 = Int32.Parse(value); } }

        private int answer6 { get; set; }
        public string Answer6 { get { return answer6.ToString(); } set { answer6 = Int32.Parse(value); } }

        private int answer7 { get; set; }
        public string Answer7 { get { return answer7.ToString(); } set { answer7 = Int32.Parse(value); } }

        private int answer8 { get; set; }
        public string Answer8 { get { return answer8.ToString(); } set { answer8 = Int32.Parse(value); } }

        private int answer9 { get; set; }
        public string Answer9 { get { return answer9.ToString(); } set { answer9 = Int32.Parse(value); } }

        private int answer10 { get; set; }
        public string Answer10 { get { return answer10.ToString(); } set { answer10 = Int32.Parse(value); } }

        private int answer11 { get; set; }
        public string Answer11 { get { return answer11.ToString(); } set { answer11 = Int32.Parse(value); } }

        private int answer12 { get; set; }
        public string Answer12 { get { return answer12.ToString(); } set { answer12 = Int32.Parse(value); } }

        private int answer13 { get; set; }
        public string Answer13 { get { return answer13.ToString(); } set { answer13 = Int32.Parse(value); } }

        private int answer14 { get; set; }
        public string Answer14 { get { return answer14.ToString(); } set { answer14 = Int32.Parse(value); } }

        private int answer15 { get; set; }
        public string Answer15 { get { return answer15.ToString(); } set { answer15 = Int32.Parse(value); } }

        private int answer16 { get; set; }
        public string Answer16 { get { return answer1.ToString(); } set { answer16 = Int32.Parse(value); } }

        private int answer17 { get; set; }
        public string Answer17 { get { return answer17.ToString(); } set { answer17 = Int32.Parse(value); } }

        private int answer18 { get; set; }
        public string Answer18 { get { return answer18.ToString(); } set { answer18 = Int32.Parse(value); } }

        private int answer19 { get; set; }
        public string Answer19 { get { return answer19.ToString(); } set { answer19 = Int32.Parse(value); } }

        private int answer20 { get; set; }
        public string Answer20 { get { return answer20.ToString(); } set { answer20 = Int32.Parse(value); } }
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