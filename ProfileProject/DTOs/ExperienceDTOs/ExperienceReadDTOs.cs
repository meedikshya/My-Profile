namespace ProfileProject.DTOs.ExperienceDTOs
{
    public class ExperienceReadDTOs
    {
        public int ExperienceId { get; set; }
        public required string ExperienceTitle { get; set; }
        public required string ExperienceOrganization { get; set; }

        public required string ExperienceLocation { get; set; }
        public required DateTime ExperienceDate { get; set; }
        public required string ExperienceResponsibilities { get; set; }
        public int UserId { get; set; }
    }
}
