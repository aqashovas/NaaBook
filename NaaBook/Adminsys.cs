using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook
{
    public class Adminsys: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["AdminLogin"] == null)
            {
                filterContext.Result = new RedirectResult("~/manage/loginsystem");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}