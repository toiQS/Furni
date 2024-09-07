using Furni.Data;
using Furni.Entities;
using Furni.Services.cart;
using Furni.Services.product;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.item
{
    public class ItemServices : IItemServices
    {
        private readonly ApplicationDbContext _context;
        private IRepositoryAsync<Item> _repository;
        private IProductServices _productServices;
        private ICartServices _cartServices;
        private string _path = string.Empty, _fileName = "LogItemFile.txt", _folderName = "item";
        // Constructor for api controller
        public ItemServices(ApplicationDbContext context)
        {
            _context = context;
            _repository = new RepositoryAsync<Item>(context);
            _repository.GetFileName(_fileName);
            _repository.GetFolderName(_folderName);
            _path = _repository.GetPathFolderCurrent();
            _productServices = new ProductServices(context);
            _cartServices = new CartServices(context);
        }
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _repository.GetValuesAsync();
        }
        public async Task<Item> GetItemAsync(string id)
        {
            try
            {
                return await _context.Item.AsNoTracking().FirstOrDefaultAsync(x => x.ItemId == id);
            }
            catch (Exception ex)
            {
                await _repository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<IEnumerable<Item>> GetItemByCartId(string cartId)
        {
            try
            {
                return await _context.Item.AsNoTracking().Where(x => x.CartId == cartId).ToListAsync();
            }
            catch (Exception ex)
            {
                await _repository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> CreateAsync(string productId, int quantity, string cartId)
        {
            try
            {
                var isCheckProduct = await _productServices.GetProductById(productId);
                var isCheckCart = await _cartServices.GetCartByIdAsync(cartId);
                if (isCheckProduct == null || isCheckCart == null) return false;
                var item = new Item()
                {
                    CartId = cartId,
                    Quantity = quantity,
                    ProductId = productId,
                    Price = isCheckProduct.Price,
                    ItemId = $"item{DateTime.Now}",
                    Total = quantity * isCheckProduct.Price,
                };
                return await _repository.Create(item);
            }
            catch (Exception ex)
            {
                await _repository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> UpdateAsync(string itemId, int quantity)
        {
            try
            {
                var data = await _context.Item.AsNoTracking().FirstOrDefaultAsync(x => x.ItemId == itemId);
                if (data == null) return false;
                data.Quantity = quantity;
                data.Total = quantity * data.Price;
                return await _repository.Update(data);
            }
            catch (Exception ex)
            {
                await _repository.LogErrorAsync(ex.Message, ex);
                throw;
            }
        }
        public async Task<bool> DeleteAsync(string itemId)
        {
            try
            {
                var data = await _context.Item.AsNoTracking().FirstOrDefaultAsync(x => x.ItemId == itemId);
                if (data == null) return false;
                return await _repository.Delete(data);
            }
            catch (Exception ex)
            {
                await _repository.LogErrorAsync(ex.Message, ex);
                throw;
            }
        }
    }
}
