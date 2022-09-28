using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;
using System.IO;

namespace WebClinet.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderTemporaryService _orderTemporaryService;
        private readonly IOrderService  _orderService;
        private readonly IOrderDetaiService  _orderDetaiService;
        private readonly IEmailService _emailService;

        public OrderController(
            IProductService productService, 
            IOrderTemporaryService orderTemporaryService,
            IOrderService orderService, 
            IOrderDetaiService orderDetaiService,
            IEmailService emailService
            )
        {
            _productService = productService;
            _orderTemporaryService = orderTemporaryService;
            _orderService = orderService;
            _orderDetaiService = orderDetaiService;
            _emailService = emailService;
        }

        // GET: Order
        public ActionResult Index()
        {
           
            return View();
        }
        public async Task<ActionResult> Cart()
        {
            var list = await _orderTemporaryService.Getall().ToListAsync();

            ViewBag.TotalProduct = list.Sum(x => (x.Amount * x.UnitPrice));
            ViewBag.Ship = 250;

            return View(list);
        }
        public async Task<ActionResult> CheckUot()
        {
            var list = await _orderTemporaryService.Getall().ToListAsync();

            ViewBag.TotalProduct = list.Sum(x => (x.Amount * x.UnitPrice));
            ViewBag.Ship = 250;
            return View(list);
        }
        public async Task<JsonResult> OrderCheck(int id)
        {
            int index = 0;
            string session = (string)Session["Cart"];
            var data = _productService.FindT(id);
            var list = _orderTemporaryService.Getall().ToList();
            //if (!list)
            //{
            OrderTemporaryViewModel orderView = new OrderTemporaryViewModel();
                orderView.Amount = 1;
                orderView.Img = data.ProductImage;
                orderView.ProductId = data.ProductID;
                orderView.Sesion = session;
                orderView.UnitPrice = data.Price;
                await _orderTemporaryService.Add(orderView);
            //  }
            index = _orderTemporaryService.Getall().ToList().Count();

            return Json(new { code = 200, Data = index }, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> Playmal(OrderViewModel orderView )
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            else
            {
                await _orderService.Add(orderView);
                int data = _orderService.Getall().ToList().FirstOrDefault().Id;
                var list = await _orderTemporaryService.Getall().ToListAsync();
                foreach (var item in list)
                {
                    OrderDetailVm orderDetailViewModel = new OrderDetailVm();
                    orderDetailViewModel.OrderID = data;
                    orderDetailViewModel.Price = item.UnitPrice;
                    orderDetailViewModel.ProductID = item.ProductId;
                    orderDetailViewModel.Quantity = item.Amount;
                    await _orderDetaiService.Add(orderDetailViewModel);
                    await _orderTemporaryService.Delete(item.ProductId);
                }

                // Giu gmail //
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Temple/gmail.html"));
                content = content.Replace("{{hello}}", "aloalaolaoaloalo");
                _emailService.Send(orderView.ShipEmail, "Cảm ơn bạn", content);
                
                return Json(new { code = 200}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}