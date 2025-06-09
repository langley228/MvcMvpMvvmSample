using MvcMvpMvvmSample.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcMvpMvvmSample.Business.Services
{
    public class ProductService
    {
        private static List<Product> _products = new List<Product>();
        private static int _nextId = 1;

        public IEnumerable<Product> GetAll() => _products;

        public void Add(string name)
        {
            _products.Add(new Product { Id = _nextId++, Name = name });
        }

        public void Update(int id, string name)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = name;
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null) _products.Remove(product);
        }
    }
}