using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UsersService
{
    public class UsersService : IUsersService
    {
        private static readonly HttpClient Client = new HttpClient();
        private static readonly string UsersApiAddress = ConfigurationManager.AppSettings[nameof(UsersApiAddress)];
        public async Task<string> AddUser(User userModel)
        {
            var response = await Client.PostAsync(UsersApiAddress, GetStringContent(userModel));

            if (response.IsSuccessStatusCode)
            {
                return response.Headers.Location.ToString();
            }

            return null;
        }

        public async Task<User> GetUser(int userId)
        {
            var response = await Client.GetAsync($"{UsersApiAddress}/{userId}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var response = await Client.GetAsync(UsersApiAddress);

            return JsonConvert.DeserializeObject<IEnumerable<User>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> UpdateUser(User userModel)
        {
            var response = await Client.PutAsync($"{UsersApiAddress}/{userModel.Id}", GetStringContent(userModel));

            if (response.IsSuccessStatusCode)
            {
                return response.Headers.Location.ToString();
            }

            return null;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var response = await Client.DeleteAsync($"{UsersApiAddress}/{userId}");

            return response.IsSuccessStatusCode;
        }

        private StringContent GetStringContent(User userModel)
        {
            var objectJson = JsonConvert.SerializeObject(userModel);

            return new StringContent(objectJson, Encoding.UTF8, "application/json");
        }
    }
}
