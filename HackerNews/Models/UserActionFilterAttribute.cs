using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackerNews.Models
{
    public class UserActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return;
            }

            var mgr = new UserManager(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True");

            filterContext.Controller.ViewBag.User =
                mgr.GetUserByUserName(filterContext.HttpContext.User.Identity.Name);
        }
    }
}