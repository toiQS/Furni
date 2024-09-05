using Furni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.product
{
    public interface IProductServices
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<IEnumerable<Product>> GetProductsByText(string text);
        public Task<IEnumerable<Product>> SortProductByPrice();
        public Task<Product> GetProductById(string productId);
        public Task<bool> CreateAsync(string productName, float price, string imageUrl);
        public Task<bool> UpdateAsync(string productId, string productName, float price, string imageUrl);
        public Task<bool> UpdateAsync(string productId);
        public Task<bool> DeleteAsync(string productId);
    }
}
