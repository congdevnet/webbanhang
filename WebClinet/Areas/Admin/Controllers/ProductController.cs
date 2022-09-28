﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebChuyenDe.Data.ViewModel;
using WebChuyenDen.Interface;

namespace WebClinet.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _NewService;
        private readonly IProductCategoryService _productCategoryService;
        public ProductController(IProductService NewService,
            IProductCategoryService productCategoryService
            )

        {
            _NewService = NewService;
            _productCategoryService = productCategoryService;
            ViewBag.header = "Bảng sản phẩm";
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
            var data = await _NewService.GetAllPage(pageSetup);
            ViewBag.Page = data.Page;
            ViewBag.PageSize = data.PageSize;
            ViewBag.TotalPage = data.TotalPage;
            return View(data.Items);
        }

        [HttpPost]
        public async Task<JsonResult> Add(ProductVm NewView)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            if (NewView.ProductID < 1)
            {
                await _NewService.Add(NewView);
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                await _NewService.Update(NewView);
                return Json(new { code = 300 }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetById(int id)
        {
            var data = await _NewService.GetT(id);
            var datadto = AutoMapper.Mapper.Map<ProductViewModel, ProductVm>(data);
            return Json(new { code = 200, Data = datadto }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _NewService.Delete(id);
            return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
        }
        private void SetViewbag()
        {
            var Categorylist = _productCategoryService.Getall().ToList();
            // Tạo SelectList
            SelectList cateList = new SelectList(Categorylist, "CategoryID", "Name");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
        }
    }
}