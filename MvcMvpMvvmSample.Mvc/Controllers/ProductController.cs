using Microsoft.AspNetCore.Mvc;
using MvcMvpMvvmSample.Business.Services;
using MvcMvpMvvmSample.Data.Models;

namespace MvcMvpMvvmSample.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        // 產品列表 (Read)
        public IActionResult Index()
        {
            var products = _service.GetAll();
            return View(products);
        }

        // 新增產品畫面
        public IActionResult Create()
        {
            return View();
        }

        // 新增產品 (Create)
        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                _service.Add(name);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // 編輯產品畫面
        public IActionResult Edit(int id)
        {
            var product = _service.GetAll().FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // 編輯產品 (Update)
        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            _service.Update(id, name);
            return RedirectToAction(nameof(Index));
        }

        // 刪除產品 (Delete)
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}