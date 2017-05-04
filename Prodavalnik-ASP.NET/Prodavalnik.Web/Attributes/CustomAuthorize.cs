namespace Prodavalnik.Web.Attributes
{
    using System.Linq;
    using System.Web.Mvc;
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = this.Roles.Split(',');
            if (filterContext.RequestContext.HttpContext.Request.IsAuthenticated &&
                !roles.Any(filterContext.HttpContext.User.IsInRole))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Error/NotFound.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }

        }
    }
}