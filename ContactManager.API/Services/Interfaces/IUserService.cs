using ContactManager.API.Models.Contracts.Response;

namespace ContactManager.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> UploadUserCSV(IFormFile file);
        Task<IEnumerable<UserResponse>> GetAllUser();
        Task<UserResponse> DeleteUserAsync(Guid id);
    }
}
