using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessLayer.Services.Interfaces;
using DTO;

namespace UsersServiceApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
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

            return Request.CreateResponse(HttpStatusCode.OK, userEntities);
        }

        [Route("")]
        public async Task<HttpResponseMessage> Post([FromBody] UserEntity userEntity)
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
