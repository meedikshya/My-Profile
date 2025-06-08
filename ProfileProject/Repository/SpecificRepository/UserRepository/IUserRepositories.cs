using ProfileProject.Models;
using ProfileProject.Repository.GenericRepository;

namespace ProfileProject.Repository.SpecificRepository.UserRepository
{
    public interface IUserRepositories : IGenericRepositories<User>
    {
    }
}