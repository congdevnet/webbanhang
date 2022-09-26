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
            if (userLoginViewModel.Equals(string.Empty))
            {
                var url = new RouteValueDictionary(new { controller = "Loginadmin", action = "Login", Area = "Admin" });
                filterContext.Result = new RedirectToRouteResult(url);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}