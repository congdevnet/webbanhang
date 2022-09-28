using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebChuyenDe.Common;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;

namespace WebClinet.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Session[CommonConst.SessionUser] != null)
            {
                return RedirectToAction("Index", "HomeAdmin");
            }    
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logins(UserLoginViewModel userLoginView)
        {
            if (ModelState.IsValid)
            {
                userLoginView.Password = PaswordHash.GetMD5(userLoginView.Password);
                
                if ( await _userService.Login(userLoginView))
                {
                    //add session
                    Session["UserName"] = userLoginView.Username;
                    Session.Add(CommonConst.SessionUser, userLoginView);

                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại!";
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "Login");
        }

    }
}