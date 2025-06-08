namespace ProfileProject.Models
{
    public class TechnicalSkill
    {
        public int TechnicalSkillId { get; set; }
        public required string TechnicalSkillType { get; set; }
        public required string TechnicalSkillItem { get; set; }
        public int UserId { get; set; }


    }
}
