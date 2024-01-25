using Microsoft.AspNetCore.Mvc.Filters;

namespace ASp_MVC.Filters

{
    public class UniqUserFilter : Attribute, IActionFilter
    {
        private static HashSet<string> uniqueUserIds = new HashSet<string>();
        private static string logFilePath = Path.Combine(Directory.GetCurrentDirectory(),  "unique_users_amount_log.txt");
        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string userId = context.HttpContext.Request.Cookies["userId"];

            if (!uniqueUserIds.Contains(userId))
            {
                uniqueUserIds.Add(userId);

                string timeOfCreating = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string logMessage = $"{timeOfCreating} - unique users amount: [{uniqueUserIds.Count}]";


                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);

            }
        }

       

    }
}