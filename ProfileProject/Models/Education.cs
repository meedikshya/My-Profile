using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace ProfileProject.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public required string EducationDegree { get; set; }
        public required string EducationInstitution { get; set; }
        public required string EducationLocation { get; set; }
        public required DateTime EducationDate { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }


    }
}
