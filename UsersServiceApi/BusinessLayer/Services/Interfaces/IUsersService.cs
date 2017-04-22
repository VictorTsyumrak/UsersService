using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUsersService
    { 
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> GetUserAsync(int id);
        Task<int> AddUserAsync(UserEntity userEntity);
        Task<bool> UpdateUserAsync(int id, UserEntity userEntity);
        Task<bool> DeleteUserAsync(int id);
    }
}
