using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelManagemnetSystemHW.Filters
{
    public class CookiesResourseFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext _)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss"));
        }
    }
}
