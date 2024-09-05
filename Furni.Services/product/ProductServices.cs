using Furni.Data;
using Furni.Entities;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Furni.Services.product
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;
        private string _path = string.Empty, _fileName = "LogProductFile.txt", _folderName = "product";
        private IRepositoryAsync<Product> _repositoryProduct;
        // Constructor for api controller
        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
            _repositoryProduct = new RepositoryAsync<Product>(context);
            _repositoryProduct.GetFileName(_fileName);
            _repositoryProduct.GetFolderName(_folderName);
            _path = _repositoryProduct.GetPathFolderCurrent();
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repositoryProduct.GetValuesAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByText(string text)
        {
            try
            {
                return await _context.Product.AsNoTracking().Where(x => x.ProductName.ToLower().Contains(text.ToLower())).ToListAsync();
            }
            catch (Exception ex)
            {
                await _repositoryProduct.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<IEnumerable<Product>> SortProductByPrice()
        {
            try
            {
                var data = await _context.Product.AsNoTracking().ToArrayAsync();
                return SortArray(data,0, data.Length-1);
            }
            catch (Exception ex)
            {
                await _repositoryProduct.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<Product> GetProductById(string productId)
        {
            try
            {
                return await _context.Product.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == productId);

            }
            catch (Exception ex)
            {
                await _repositoryProduct.LogErrorAsync(_path,ex);
                throw;
            }
        }
        public async Task<bool> CreateAsync(string productName, float price, string imageUrl)
        {
            try
            {
                var product = new Product()
                {
                    ProductName = productName,
                    IsActive = true,
                    Price = price,
                    ProductId = $"product{DateTime.Now}",
                    URLImage = imageUrl
                };
                return await _repositoryProduct.Create(product);
            }
            catch (Exception ex)
            {
                await _repositoryProduct.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> UpdateAsync(string productId, string productName, float price, string imageUrl)
        {
            try
            {
                var data = await _context.Product.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == productId);
                if (data == null) return false;
                data.ProductName = productName;
                data.Price = price;
                data.ProductId = productId;
                return await _repositoryProduct.Update(data);

            }
            catch (Exception ex)
            {
                await _repositoryProduct.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> UpdateAsync(string productId)
        {
            try
            {
                var data = await _context.Product.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == productId);
                if (data == null) return false;
                data.IsActive = !data.IsActive;
                return await _repositoryProduct.Update(data);

            }
            catch (Exception ex)
            {
                await _repositoryProduct.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> DeleteAsync(string productId)
        {
            try
            {
                var data = await _context.Product.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == productId);
                if (data == null) return false;
                return await _repositoryProduct.Delete(data);

            }
            catch (Exception ex)
            {
                await _repositoryProduct.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public Product[] SortArray(Product[] products, int l, int r)
        {
            int i = l, j = r;
            var pivot = products[l].Price;
            while (i <= j)
            {
                while (products[i].Price < pivot)
                {
                    i++;
                }
                while (products[i].Price > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    float temp = products[i].Price;
                    products[i].Price = products[j].Price;
                    products[j].Price = temp;
                    i++;
                    j--;
                }
            }
            if (l < j)
            {
                SortArray(products, l, j);
            }
            if (i < r)
            {
                SortArray(products, i,r);
            }
            return products;
        }
    }
}
