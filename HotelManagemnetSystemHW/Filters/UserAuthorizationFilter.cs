using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelManagemnetSystemHW.Filters
{
    public class UserAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private string _username;
        private string _password;

        public UserAuthorizationFilter(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(_username == "admin" && _password == "admin123")
            {
                context.Result = new ContentResult { Content = "Пользователь 'admin' авторизован" };
            }
            else
            {
                context.Result = new ContentResult { Content = "Доступ запрещен" };
            }
        }
    }
}
