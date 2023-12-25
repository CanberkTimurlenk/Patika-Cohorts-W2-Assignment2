using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.ActionFilters
{
    public class CustomAuthorized : ActionFilterAttribute
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
