namespace ProfileProject.DTOs.UserDTOs
{
    public class UserReadDTOs
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string UserPhone { get; set; }
        public required string UserEmail { get; set; }
        public required string UserGithub { get; set; }
        public required string UserLinkedin { get; set; }
        public required string UserSummary { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
