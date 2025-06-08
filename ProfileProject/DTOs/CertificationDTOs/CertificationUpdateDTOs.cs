namespace ProfileProject.DTOs.CertificationDTOs
{
    public class CertificationUpdateDTOs
    {
        public int CertificationId { get; set; }
        public int UserId { get; set; }
        public required string CertificationName { get; set; }
        public required String CertificationLink { get; set; }
    }
}
