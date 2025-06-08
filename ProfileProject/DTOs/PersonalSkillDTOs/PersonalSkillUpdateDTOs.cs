namespace ProfileProject.DTOs.PersonalSkillDTOs
{
    public class PersonalSkillUpdateDTOs
    {
        public int PersonalSkillId { get; set; }
        public required string PersonalSkillType { get; set; }
        public required string PersonalSkillItems { get; set; }
        public int UserId { get; set; }
    }
}
