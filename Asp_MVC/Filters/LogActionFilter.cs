using Microsoft.AspNetCore.Mvc.Filters;

namespace ASp_MVC.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private static string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "action_log.txt");

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();
            string timeOfCreating = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"{timeOfCreating} - Controller: {controllerName}, Action: {actionName}";


            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }

        //public LogActionFilter(ILogger<LogActionFilter> logger)
        //{
        //    _logger = logger;
        //}

        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    var methodName = context.ActionDescriptor.DisplayName;
        //    var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        //    var logMessage = $"Method {methodName} called at {timestamp}";
        //    _logger.LogInformation(logMessage);

        //}

        //public void OnActionExecuted(ActionExecutedContext context)
        //{

        //}
    }
}
