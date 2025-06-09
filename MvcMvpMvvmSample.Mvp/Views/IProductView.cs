using System.Collections.Generic;
using MvcMvpMvvmSample.Data.Models;

namespace MvcMvpMvvmSample.Mvp.Views
{
    public interface IProductView
    {
        IEnumerable<Product> Products { get; set; }
        Product EditProduct { get; set; }
        string Message { get; set; }
    }
}