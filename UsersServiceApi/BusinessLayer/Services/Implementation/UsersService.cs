using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services.Interfaces;
using DataLayer;
using DataLayer.Models;
using DTO;
using log4net;

namespace BusinessLayer.Services.Implementation
{
    //LogContextsHanshes applied only for test purposes (check if DI works as expected, 1 instace of DbContext per call)
    public class UsersService : IUsersService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UsersService));
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Company> _companyRepository;
        public UsersService(IRepository<User> userRepository, IRepository<Company> companyRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }
        public async Task<int> AddUserAsync(UserEntity userEntity)
        {
            LogContextsHanshes();
            if (userEntity != null)
            {
                var userModel = _mapper.Map<User>(userEntity);
                _userRepository.Add(userModel);
                await _userRepository.SaveChangesAsync();

                LogContextsHanshes();
                return userModel.Id;
            }

            LogContextsHanshes();
            return 0;
        }

        public async Task<UserEntity> GetUserAsync(int id)
        {
            LogContextsHanshes();
            var user = await _userRepository.GetAsync(id);
            LogContextsHanshes();

            return _mapper.Map<UserEntity>(user);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            LogContextsHanshes();
            var users = await _userRepository.GetAsync();
            LogContextsHanshes();

            return _mapper.Map<IEnumerable<UserEntity>>(users);
        }

        public async Task<bool> UpdateUserAsync(int id, UserEntity userEntity)
        {
            LogContextsHanshes();
            var user = await _userRepository.GetAsync(id);
            LogContextsHanshes();

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
            LogContextsHanshes();
            var user = await _userRepository.GetAsync(id);
            LogContextsHanshes();

            if (user != null)
            {
                _userRepository.Delete(user);
                await _userRepository.SaveChangesAsync();
                return true;
            }

            LogContextsHanshes();
            return false;
        }

        private void LogContextsHanshes()
        {
            var usersContextHash = _userRepository.ContextHashCode;
            var companiesContextHash = _companyRepository.ContextHashCode;

            Logger.Info($"UsersServiceHash= {GetHashCode()}, UsersContextHash = {usersContextHash}, CompaniesContextHash = {companiesContextHash}, AreEqual={usersContextHash == companiesContextHash}");
        }
    }
}
