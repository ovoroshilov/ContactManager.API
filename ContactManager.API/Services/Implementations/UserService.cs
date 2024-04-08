using ContactManager.API.Models.Contracts.CSVMaps;
using ContactManager.API.Models.Contracts.Request;
using ContactManager.API.Models.Contracts.Response;
using ContactManager.API.Models.Entities;
using ContactManager.API.Repositories.Interfaces;
using ContactManager.API.Services.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ContactManager.API.Services.Implementations
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> DeleteUserAsync(Guid id)
        {
            try
            {
                var existingUser = await _userRepository.DeleteUserAsync(id);
                if (existingUser is not null)
                {
                    var response = new UserResponse
                    {
                        Id = existingUser.Id,
                        Name = existingUser.Name,
                        DateOfBirth = existingUser.DateOfBirth,
                        Salary = existingUser.Salary,
                        Phone = existingUser.Phone,
                        Married = existingUser.Married
                    };
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserResponse>> GetAllUser()
        {
            var userEntities = await _userRepository.GetAllUsersAsync();
            var response = userEntities.Select(entity => new UserResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Married = entity.Married,
                DateOfBirth = entity.DateOfBirth,
                Phone = entity.Phone,
                Salary = entity.Salary
            });
            return response;
        }

        public async Task<int> UploadUserCSV(IFormFile file)
        {
            var users = new List<CreateUserRequest>();
            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<CreateUserMap>();
                users.AddRange(csv.GetRecords<CreateUserRequest>().ToList());
            }
            var userEntities = new List<UserEntity>();
            userEntities.AddRange(users.Select(user => new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Married = user.Married,
                DateOfBirth = user.DateOfBirth,
                Phone = user.Phone,
                Salary = user.Salary
            }));
            await _userRepository.CreateUsersAsync(userEntities);
            return userEntities.Count;
        }
    }
}
