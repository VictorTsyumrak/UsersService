using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessLayer.Services.Interfaces;
using DataLayer;
using DataLayer.Models;
using DTO;

namespace UsersServiceApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IRepository<Company> _companiesRepository;
        private readonly IUsersService _usersService;

        public UsersController(IRepository<User> usersRepository, IRepository<Company> companiesRepository, IUsersService usersService)
        {
            _usersRepository = usersRepository;
            _companiesRepository = companiesRepository;
            _usersService = usersService;
        }

        [Route("{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            var userEntity = await _usersService.GetUserAsync(id);
            if (userEntity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, userEntity);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"User with Id={id} does not exists");
        }

        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            var userEntities = await _usersService.GetAllUsersAsync();
            if (userEntities != null && userEntities.Any())
            {
               return Request.CreateResponse(HttpStatusCode.OK, userEntities);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Requested users not found");
        }

        [Route("")]
        public async Task<HttpResponseMessage> Post([FromBody] UserEntity userEntity)
        {
            if (Equals(_usersRepository.Context, _companiesRepository.Context))
            {
                var userId = await _usersService.AddUserAsync(userEntity);
                if (userId != 0)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Created);
                    responseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{userId}");

                    return responseMessage;
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User can't be created");
            }

            return Request.CreateErrorResponse(HttpStatusCode.Conflict, string.Empty);
        }

        [Route("{id:int}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] UserEntity userEntity)
        {
            var isSuccessful = await _usersService.UpdateUserAsync(id, userEntity);
            if (isSuccessful)
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                responseMessage.Headers.Location = Request.RequestUri;

                return responseMessage;
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"User with Id={id} does not exists");
        }

        [Route("{id:int}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var isSuccessful = await _usersService.DeleteUserAsync(id);
            if (isSuccessful)
            {
                return Request.CreateResponse(HttpStatusCode.OK, string.Empty);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"User with Id={id} does not exists");
        }
    }
}
