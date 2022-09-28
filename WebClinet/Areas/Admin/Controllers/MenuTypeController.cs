using System.Threading.Tasks;
using System.Web.Mvc;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;

namespace WebClinet.Areas.Admin.Controllers
{
    public class MenuTypeController : BaseController
    {
        private readonly IMenuTypeService _MenuTypeService;

        public MenuTypeController(IMenuTypeService MenuTypeService)

        {
            _MenuTypeService = MenuTypeService;
            ViewBag.header = "Bảng MenuType";
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
            var data = await _MenuTypeService.GetAllPage(pageSetup);
            ViewBag.Page = data.Page;
            ViewBag.PageSize = data.PageSize;
            ViewBag.TotalPage = data.TotalPage;
            return View(data.Items);
        }

        [HttpPost]
        public async Task<JsonResult> Add(MenuTypeViewModel MenuTypeView)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            if (MenuTypeView.MenuTypeID < 1)
            {
                await _MenuTypeService.Add(MenuTypeView);
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                await _MenuTypeService.Update(MenuTypeView);
                return Json(new { code = 300 }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetById(int id)
        {
            var data = await _MenuTypeService.GetT(id);
            return Json(new { code = 200, Data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _MenuTypeService.Delete(id);
            return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
        }
    }
}