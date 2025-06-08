using AutoMapper;
using ProfileProject.Models;
using ProfileProject.DTOs.UserDTOs;
using ProfileProject.DTOs.CertificationDTOs;
using ProfileProject.DTOs.EducationDTOs;
using ProfileProject.DTOs.ExperienceDTOs;
using ProfileProject.DTOs.PersonalSkillDTOs;
using ProfileProject.DTOs.ProjectDTOs;
using ProfileProject.DTOs.TechnicalSkillDTOs;

namespace ProfileProject.Profiles
{
    public class ResumeProfile : Profile
    {
        public ResumeProfile()
        {

            // User mappings
            CreateMap<User, UserReadDTOs>();
            CreateMap<UserCreateDTOs, User>();
            CreateMap<UserUpdateDTOs, User>();

            // Certification mappings
            CreateMap<Certification, CertificationReadDTOs>();
            CreateMap<CertificationCreateDTOs, Certification>();
            CreateMap<CertificationUpdateDTOs, Certification>();

            // Education mappings
            CreateMap<Education, EducationReadDTOs>();
            CreateMap<EducationCreateDTOs, Education>();
            CreateMap<EducationUpdateDTOs, Education>();

            // Experience mappings
            CreateMap<Experience, ExperienceReadDTOs>();
            CreateMap<ExperienceCreateDTOs, Experience>();
            CreateMap<ExperienceUpdateDTOs, Experience>();

            // PersonalSkill mappings
            CreateMap<PersonalSkill, PersonalSkillReadDTOs>();
            CreateMap<PersonalSkillCreateDTOs, PersonalSkill>();
            CreateMap<PersonalSkillUpdateDTOs, PersonalSkill>();

            // Project mappings
            CreateMap<Project, ProjectReadDTOs>();
            CreateMap<ProjectCreateDTOs, Project>();
            CreateMap<ProjectUpdateDTOs, Project>();

            // TechnicalSkill mappings
            CreateMap<TechnicalSkill, TechnicalSkillReadDTOs>();
            CreateMap<TechnicalSkillCreateDTOs, TechnicalSkill>();
            CreateMap<TechnicalSkillUpdateDTOs, TechnicalSkill>();
        }
    }
}
