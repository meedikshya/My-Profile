using Microsoft.VisualBasic;
using System.Security.Principal;

namespace ProfileProject.Models
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public required string ExperienceTitle { get; set; }
        public required string ExperienceOrganization { get; set; } 

        public required string ExperienceLocation { get; set; }
        public required DateTime ExperienceDate { get; set; }
        public required string ExperienceResponsibilities { get; set; }

        public int UserId { get; set;  }



    }
}
