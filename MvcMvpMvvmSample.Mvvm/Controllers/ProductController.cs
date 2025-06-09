using Microsoft.AspNetCore.Mvc;
using MvcMvpMvvmSample.Business.Services;
using MvcMvpMvvmSample.Mvvm.ViewModels;

namespace MvcMvpMvvmSample.Mvvm.Controllers
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
            var products = _service.GetAll()
                .Select(p => new ProductViewModel { Id = p.Id, Name = p.Name });
            return View(products);
        }

        // 新增產品畫面
        public IActionResult Create()
        {
            return View();
        }

        // 新增產品 (Create)
        [HttpPost]
        public IActionResult Create(ProductViewModel vm)
        {
            _service.Add(vm.Name);
            return RedirectToAction(nameof(Index));
        }

        // 編輯產品畫面
        public IActionResult Edit(int id)
        {
            var product = _service.GetAll().FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var vm = new ProductViewModel { Id = product.Id, Name = product.Name };
            return View(vm);
        }

        // 編輯產品 (Update)
        [HttpPost]
        public IActionResult Edit(ProductViewModel vm)
        {
            _service.Update(vm.Id, vm.Name);
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