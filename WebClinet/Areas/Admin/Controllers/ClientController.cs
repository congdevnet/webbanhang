using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;

namespace WebClinet.Areas.Admin.Controllers
{
    public class ClientController : BaseController
    {
        private IOrderService _orderService;
        private readonly IOrderDetaiService _orderDetaiService;
        public ClientController(IOrderService orderService, IOrderDetaiService orderDetaiService)
        {
            _orderService = orderService;
            _orderDetaiService = orderDetaiService;

            ViewBag.header = "Bảng khách hàng";
        }
        // GET: Admin/Client
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Datatable(int? page = 1)
        {
            PageSetup pageSetup = new PageSetup((int)page);
            var data = await _orderService.GetAllPage(pageSetup);
            ViewBag.Page = data.Page;
            ViewBag.PageSize = data.PageSize;
            ViewBag.TotalPage = data.TotalPage;
            return View(data.Items);
        }
        [HttpPost]
        public async Task<JsonResult> GetById(int id)
        {
            var dto =  await _orderDetaiService.Getall().ToListAsync();
            var data = dto.Where(x => x.OrderID == id).ToList();
            var oders = data.FirstOrDefault().Order;
            List<ProductVm> productVms = new List<ProductVm>();
            foreach (var item in data)
            {
                var ProMap = Mapper.Map<ProductViewModel, ProductVm>(item.Product);
                productVms.Add(ProMap);
            }
            ViewBag.Products = productVms;
            return Json(new { code = 200, Data = oders }, JsonRequestBehavior.AllowGet);
        }
    }
}