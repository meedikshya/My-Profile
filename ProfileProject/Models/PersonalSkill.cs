using System.Security.Principal;

namespace ProfileProject.Models
{
    public class PersonalSkill
    {
        public int PersonalSkillId { get; set; }

        public required string PersonalSkillType { get; set; }
        public required string PersonalSkillItems { get; set; }
        public int UserId { get; set; }
}
}
