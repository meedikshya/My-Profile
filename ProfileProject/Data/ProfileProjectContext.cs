using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfileProject.Models;

namespace ProfileProject.Data
{
    public class ProfileProjectContext : DbContext
    {
        public ProfileProjectContext()
        {
        }

        public ProfileProjectContext(DbContextOptions<ProfileProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ProfileProject.Models.User> User { get; set; } = default!;
        public DbSet<ProfileProject.Models.Experience> Experience { get; set; } = default!;
        public DbSet<ProfileProject.Models.Education> Education { get; set; } = default!;
        public DbSet<ProfileProject.Models.Project> Project { get; set; } = default!;
        public DbSet<ProfileProject.Models.Certification> Certification { get; set; } = default!;
        public DbSet<ProfileProject.Models.TechnicalSkill> TechnicalSkill { get; set; } = default!;
        public DbSet<ProfileProject.Models.PersonalSkill> PersonalSkill { get; set; } = default!;

        }
    }