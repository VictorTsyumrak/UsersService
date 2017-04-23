using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UsersService
{
    [ServiceContract]
    public interface IUsersService
    {
        [OperationContract]
        Task<string> AddUser(User userModel);

        [OperationContract]
        Task<User> GetUser(int userId);

        [OperationContract]
        Task<IEnumerable<User>> GetUsers();

        [OperationContract]
        Task<string> UpdateUser(User userModel);

        [OperationContract]
        Task<bool> DeleteUser(int userId);
    }
}
