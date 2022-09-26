using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebChuyenDen.Interface;
using WebClinet.Models;

namespace WebClinet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IModelData _modelData;
        private readonly IOrderTemporaryService _orderTemporaryService;
        public HomeController(IModelData modelData, IOrderTemporaryService orderTemporaryService)
        {
            _modelData = modelData;
            _orderTemporaryService = orderTemporaryService;
        }
        public async Task<ActionResult> Index()
        {
            var data = await _modelData.GetModelDatasAsync();
            Random random = new Random();
            Session["cartConut"] = _orderTemporaryService.Getall().ToList();
            if (!(Session["Cart"] != null))
            {
                Session.Add("Cart", "ABC" + random.Next(10, 999));
            }
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}