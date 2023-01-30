using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppCoreAPI.Authentication
{
    public class Logged : Attribute, IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            string? token = context.HttpContext.Request.Headers.Authorization;

            if (token == null)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                var d = await AuthService.IsTokenValid(token.ToString());
                if (d == 0)
                {
                    context.Result = new UnauthorizedResult();
                }
                else if (d == 1)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
