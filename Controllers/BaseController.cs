using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_CNPM.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admin"] == null)// Chưa đăng nhập Admin
            {
                //Thì trả về màn hình đăng nhập admin
                filterContext.Result = new RedirectToRouteResult(
                      new System.Web.Routing.RouteValueDictionary(new { Controller = "Default", Action = "LogIn" })
                );
            }
            base.OnActionExecuting(filterContext);
        }
    }
}