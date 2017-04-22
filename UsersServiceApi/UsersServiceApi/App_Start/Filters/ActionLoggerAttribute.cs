using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using log4net;

namespace UsersServiceApi.Filters
{
    public class ActionLoggerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controllerType = actionContext.ControllerContext.Controller.GetType();
            var logger = LogManager.GetLogger(controllerType);
           
            logger.Info($"Request: {actionContext.Request}");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var actionContext = actionExecutedContext.ActionContext;
            var controllerType = actionContext.ControllerContext.Controller.GetType();
            var logger = LogManager.GetLogger(controllerType);

            logger.Info($"Reponse: {actionExecutedContext.Response}");
        }
    }
}