using ContactManager.API.Models.Entities;

namespace ContactManager.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUsersAsync(List<UserEntity> users);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> DeleteUserAsync(Guid id);
    }
}
