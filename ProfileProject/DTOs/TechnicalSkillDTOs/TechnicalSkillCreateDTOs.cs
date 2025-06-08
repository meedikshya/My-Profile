namespace ProfileProject.DTOs.TechnicalSkillDTOs
{
    public class TechnicalSkillCreateDTOs
    {
        public required string TechnicalSkillType { get; set; }
        public required string TechnicalSkillItem { get; set; }
        public int UserId { get; set; }
    }
}
