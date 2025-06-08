namespace ProfileProject.DTOs.ProjectDTOs
{
    public class ProjectReadDTOs
    {
        public int ProjectId { get; set; }
        public required string ProjectName { get; set; }
        public required string ProjectDescription { get; set; }
        public required string ProjectGithubLink { get; set; }
        public required string ProjectGithub { get; set; }
        public required string ProjectDemo { get; set; }
        public int UserId { get; set; }
    }
}
