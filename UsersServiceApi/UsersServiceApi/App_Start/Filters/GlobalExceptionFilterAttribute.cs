using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using log4net;

namespace UsersServiceApi.Filters
{
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(GlobalExceptionFilterAttribute));
        public override async Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            await base.OnExceptionAsync(actionExecutedContext, cancellationToken);

            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent("Something went wrong. Oops...")
            };

            _logger.Error($"Exception occured: {actionExecutedContext.Exception.Message}");

            throw new HttpResponseException(responseMessage);
        }
    }
}