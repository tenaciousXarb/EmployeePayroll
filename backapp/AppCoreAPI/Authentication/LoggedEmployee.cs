using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppCoreAPI.Authentication
{
    public class LoggedEmployee : Attribute, IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            string? token = context.HttpContext.Request.Headers.Authorization;
            string? role = context.HttpContext.Request.Headers.Allow;

            if (token == null)
            {
                context.Result = new UnauthorizedResult();
            }
            else if (role != "employee")
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                var d = await AuthService.IsTokenValid(token.ToString());
                if (d != 2)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
