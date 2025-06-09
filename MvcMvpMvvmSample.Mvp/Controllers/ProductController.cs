using Microsoft.AspNetCore.Mvc;
using MvcMvpMvvmSample.Business.Services;
using MvcMvpMvvmSample.Data.Models;
using MvcMvpMvvmSample.Mvp.Presenters;
using MvcMvpMvvmSample.Mvp.Views;
using System.Collections.Generic;

namespace MvcMvpMvvmSample.Mvp.Controllers
{
    public class ProductController : Controller, IProductView
    {
        private readonly ProductPresenter _presenter;

        public ProductController(ProductService service)
        {
            _presenter = new ProductPresenter(this, service);
        }

        // IProductView 實作
        public IEnumerable<Product> Products { get; set; }
        public Product EditProduct { get; set; }
        public string Message { get; set; }

        // 產品列表
        public IActionResult Index()
        {
            _presenter.LoadProducts();
            ViewBag.Message = Message;
            return View(Products);
        }

        // 新增產品畫面
        public IActionResult Create() => View();

        // 新增產品
        [HttpPost]
        public IActionResult Create(string name)
        {
            _presenter.AddProduct(name);
            TempData["Message"] = Message;
            return RedirectToAction(nameof(Index));
        }

        // 編輯產品畫面
        public IActionResult Edit(int id)
        {
            _presenter.LoadEditProduct(id);
            if (EditProduct == null) return NotFound();
            return View(EditProduct);
        }

        // 編輯產品
        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            _presenter.UpdateProduct(id, name);
            TempData["Message"] = Message;
            return RedirectToAction(nameof(Index));
        }

        // 刪除產品
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _presenter.DeleteProduct(id);
            TempData["Message"] = Message;
            return RedirectToAction(nameof(Index));
        }
    }
}