using ProfileProject.Data;
using ProfileProject.Models;
using ProfileProject.Repository.GenericRepository;

namespace ProfileProject.Repository.SpecificRepository.UserRepository
{
    public class UserRepositories : GenericRepositories<User>, IUserRepositories
    {
        public UserRepositories(ProfileProjectContext context) : base(context)
        {
        }
    }
}