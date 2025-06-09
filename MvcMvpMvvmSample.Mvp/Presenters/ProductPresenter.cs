using MvcMvpMvvmSample.Business.Services;
using MvcMvpMvvmSample.Data.Models;
using MvcMvpMvvmSample.Mvp.Views;

namespace MvcMvpMvvmSample.Mvp.Presenters
{
    public class ProductPresenter
    {
        private readonly IProductView _view;
        private readonly ProductService _service;

        public ProductPresenter(IProductView view, ProductService service)
        {
            _view = view;
            _service = service;
        }

        public void LoadProducts()
        {
            _view.Products = _service.GetAll();
        }

        public void AddProduct(string name)
        {
            _service.Add(name);
            _view.Message = "新增成功";
            LoadProducts();
        }

        public void UpdateProduct(int id, string name)
        {
            _service.Update(id, name);
            _view.Message = "更新成功";
            LoadProducts();
        }

        public void DeleteProduct(int id)
        {
            _service.Delete(id);
            _view.Message = "刪除成功";
            LoadProducts();
        }

        public void LoadEditProduct(int id)
        {
            _view.EditProduct = _service.GetAll().FirstOrDefault(p => p.Id == id);
        }
    }
}