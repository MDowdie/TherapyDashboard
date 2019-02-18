using System.Collections.Generic;

namespace TherapyDashboard.Models.Database
{
    public class Enrollment
    {

        public int Id { get; set; }

        public string ParticipatingIn { get; set; } // program, such as Outreach, Court Advocacy, etc.

        public List<Assessment> Assessments { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}