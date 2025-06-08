namespace ProfileProject.DTOs.PersonalSkillDTOs
{
    public class PersonalSkillCreateDTOs
    {
        public required string PersonalSkillType { get; set; }
        public required string PersonalSkillItems { get; set; }
        public int UserId { get; set; }
    }
}
