using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelManagemnetSystemHW.Filters
{
    public class LoginActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext _)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["login"] = "user";
            context.ActionArguments["password"] = "user123";

        }
    }
}
