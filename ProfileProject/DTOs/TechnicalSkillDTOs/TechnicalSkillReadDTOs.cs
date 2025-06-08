namespace ProfileProject.DTOs.TechnicalSkillDTOs
{
    public class TechnicalSkillReadDTOs
    {
        public int TechnicalSkillId { get; set; }
        public required string TechnicalSkillType { get; set; }
        public required string TechnicalSkillItem { get; set; }
        public int UserId { get; set; }
    }
}
