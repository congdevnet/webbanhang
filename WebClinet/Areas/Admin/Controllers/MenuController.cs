using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;

namespace WebClinet.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;
        private readonly IMenuTypeService _menuTypeService;

        public MenuController(IMenuService menuService,
            IMenuTypeService menuTypeService)
        {
            _menuService = menuService;
            _menuTypeService = menuTypeService;
            ViewBag.header = "Bảng menu";
            SetViewbag();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Datatable(int? page = 1)
        {
            PageSetup pageSetup = new PageSetup((int)page);
            var data = await _menuService.GetAllPage(pageSetup);
            ViewBag.Page = data.Page;
            ViewBag.PageSize = data.PageSize;
            ViewBag.TotalPage = data.TotalPage;
            return View(data.Items);
        }

        [HttpPost]
        public async Task<JsonResult> Add(MenuVm menuView)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            if (menuView.MenuID < 1)
            {
                await _menuService.Add(menuView);
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                await _menuService.Update(menuView);
                return Json(new { code = 300 }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetById(int id)
        {
            var data = await _menuService.GetT(id);
            return Json(new { code = 200, Data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _menuService.Delete(id);
            return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
        }

        private void SetViewbag()
        {
            var Categorylist = _menuTypeService.Getall().ToList();
            // Tạo SelectList
            SelectList cateList = new SelectList(Categorylist, "MenuTypeID", "MenuName");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
        }
    }
}