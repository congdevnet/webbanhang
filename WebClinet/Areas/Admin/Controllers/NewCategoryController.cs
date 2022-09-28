using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;

namespace WebClinet.Areas.Admin.Controllers
{
    public class NewCategoryController : BaseController
    {
        private readonly INewCategoryService _NewCategoryService;

        public NewCategoryController(INewCategoryService NewCategoryService)

        {
            _NewCategoryService = NewCategoryService;
            ViewBag.header = "Bảng NewCategory";
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
            var data = await _NewCategoryService.GetAllPage(pageSetup);
            ViewBag.Page = data.Page;
            ViewBag.PageSize = data.PageSize;
            ViewBag.TotalPage = data.TotalPage;
            return View(data.Items);
        }

        [HttpPost]
        public async Task<JsonResult> Add(NewCategoryViewModel NewCategoryView)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            if (NewCategoryView.NewCategoryID < 1)
            {
                await _NewCategoryService.Add(NewCategoryView);
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                await _NewCategoryService.Update(NewCategoryView);
                return Json(new { code = 300 }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetById(int id)
        {
            var data = await _NewCategoryService.GetT(id);
            return Json(new { code = 200, Data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _NewCategoryService.Delete(id);
            return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
        }
    }
}