using Furni.Data;
using Furni.Entities;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.cart
{
    public class CartServices : ICartServices
    {
        private readonly ApplicationDbContext _context;
        private string _fileName = "LogCartFile.txt";
        private string _folderName = "cart";
        private string _path = string.Empty;
        private readonly IRepositoryAsync<Cart> _cartRepository;
        // Contructor for api
        public CartServices(ApplicationDbContext context)
        {
            _context = context;
            _cartRepository = new RepositoryAsync<Cart>(context);
            _cartRepository.GetFileName(_fileName);
            _cartRepository.GetFolderName(_folderName);
            _path = _cartRepository.GetPathFolderCurrent();
        }
        public async Task<IEnumerable<Cart>> GetCartsAsync()
        {
            return await _cartRepository.GetValuesAsync();
        }
        public async Task<Cart> GetCartByIdAsync(string id)
        {
            try
            {
                return await _context.Cart.AsNoTracking().FirstOrDefaultAsync(x => x.CartId == id);
            }
            catch (Exception ex)
            {
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<IEnumerable<Cart>> GetCartsByStatusTrue()
        {
            try
            {
                return await _context.Cart.AsNoTracking().Where(x => x.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<IEnumerable<Cart>> GetCartsByStatusFalse()
        {
            try
            {
                return await _context.Cart.AsNoTracking().Where(x => x.Status == false).ToListAsync();
            }
            catch (Exception ex)
            {
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<IEnumerable<Cart>> GetCartsByUserId(string userId)
        {
            try
            {
                return await _context.Cart.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<IEnumerable<Cart>> AdvancedSearch(string userId, bool status)
        {
            try
            {
                return await _context.Cart.AsNoTracking().Where(x => x.Status == status && x.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> CreateAsync(string userId)
        {
            var cart = new Cart()
            {
                UserId = userId,
                CartId = $"1001{DateTime.Now}",
                Status = false,
            };
            return await _cartRepository.Create(cart);
        }
        public async Task<bool> UpdateAsync(string cartId, string userId)
        {
            try
            {
                var data = await _context.Cart.AsNoTracking().Where(x => x.CartId == cartId && x.UserId == userId).FirstOrDefaultAsync();
                if (data == null) return false;
                data.Status = !data.Status;
                return await _cartRepository.Update(data);
            }
            catch (Exception ex)
            {
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> DeleteAsync(string cartId, string userId)
        {
            try
            {
                var data = await _context.Cart.AsNoTracking().Where(x => x.UserId == userId && x.CartId == cartId).FirstOrDefaultAsync();
                if (data == null) return false;
                return await _cartRepository.Delete(data);
            }
            catch (Exception ex)
            {
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
    }
}
