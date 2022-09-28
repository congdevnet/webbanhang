using System.Web.Mvc;
using System.Web.Routing;
using WebChuyenDe.Common;
using WebChuyenDe.Data.ViewModel;

namespace WebClinet.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserLoginViewModel userLoginViewModel = (UserLoginViewModel)Session[CommonConst.SessionUser];
            if (userLoginViewModel==null)
            {
                var url = new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" });
                filterContext.Result = new RedirectToRouteResult(url);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}