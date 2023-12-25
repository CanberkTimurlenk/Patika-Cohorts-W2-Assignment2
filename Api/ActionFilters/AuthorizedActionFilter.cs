using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceApi.ActionFilters
{
    public class CustomAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var username = context.HttpContext.Session.GetString("username");

            if (string.IsNullOrEmpty(username))
            {
                context.Result = new UnauthorizedObjectResult("Not Authorized");
            }
        }
    }
}
