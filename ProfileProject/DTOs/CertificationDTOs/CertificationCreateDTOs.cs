using ProfileProject.Models;

namespace ProfileProject.DTOs.CertificationDTOs
{
    public class CertificationCreateDTOs
    {
        public required string CertificationName { get; set; }
        public required string CertificationLink { get; set; }
        public int UserId { get; set; }
     
    }
}
