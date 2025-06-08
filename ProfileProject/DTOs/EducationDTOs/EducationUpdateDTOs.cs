using ProfileProject.Models;

namespace ProfileProject.DTOs.EducationDTOs
{
    public class EducationUpdateDTOs
    {
        public int EducationId { get; set; }
        public required string EducationDegree { get; set; }
        public required string EducationInstitution { get; set; }
        public required string EducationLocation { get; set; }
        public required DateTime EducationDate { get; set; }
        public int UserId { get; set; }
      
    }
}
