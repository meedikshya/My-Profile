namespace ProfileProject.DTOs.CertificationDTOs
{
    public class CertificationReadDTOs
    {
        public int CertificationId { get; set; }
        public required string CertificationName { get; set; }
        public required string CertificationLink { get; set; }
        public int UserId { get; set; }
    }
}
