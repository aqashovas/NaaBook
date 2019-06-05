using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaaBook
{
    public class EvAdmin: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["logint"] == null)
            {
                filterContext.Result = new RedirectResult("~/evaluation/loginev");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}