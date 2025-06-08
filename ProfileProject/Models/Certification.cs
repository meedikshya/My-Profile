using System.Security.Principal;

namespace ProfileProject.Models
{
    public class Certification
    {

        public int CertificationId { get; set; }
        public required String CertificationName { get; set; }
        public required String CertificationLink { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
    }
}
