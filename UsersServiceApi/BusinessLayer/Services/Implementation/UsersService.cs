using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services.Interfaces;
using DataLayer;
using DataLayer.Models;
using DTO;

namespace BusinessLayer.Services.Implementation
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        public UsersService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<int> AddUserAsync(UserEntity userEntity)
        {
            if (userEntity != null)
            {
                var userModel = _mapper.Map<User>(userEntity);
                _userRepository.Add(userModel);
                await _userRepository.SaveChangesAsync();
                return userModel.Id;
            }

            return 0;
        }

        public async Task<UserEntity> GetUserAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserEntity>(user);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAsync();
            return _mapper.Map<IEnumerable<UserEntity>>(users);
        }

        public async Task<bool> UpdateUserAsync(int id, UserEntity userEntity)
        {
            var user = await _userRepository.GetAsync(id);
            if (user != null)
            {
                _mapper.Map(userEntity, user);
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                await _userRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
