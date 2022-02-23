using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace SupermarketWebAPI.Domain.Models
{
    //ActionFilterAttribute is a class in the Microsoft.AspNetCore.Mvc.Filters and it is used for executing a code before, or after, controller actions.
    public class ApiAuthorizationFilter : ActionFilterAttribute
    {
        private List<AdministratorPermissions> _adminPermissions;

        public ApiAuthorizationFilter(AdministratorPermissions [] permissions)
        {
            _adminPermissions = new List<AdministratorPermissions>();
            _adminPermissions.AddRange(permissions);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
            }

            var permissions = GetUserPermissions(user);

            var valueFound = CheckPermissionsForValue(permissions);

            if (valueFound)
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }

        private bool CheckPermissionsForValue(object permissions)
        {
            throw new System.NotImplementedException();
        }

        private object GetUserPermissions(System.Security.Claims.ClaimsPrincipal user)
        {
            throw new System.NotImplementedException();
        }
    }
}