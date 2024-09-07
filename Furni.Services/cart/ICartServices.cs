using Furni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.cart
{
    public interface ICartServices
    {
        public Task<IEnumerable<Cart>> GetCartsAsync();
        public Task<Cart> GetCartByIdAsync(string id);
        public Task<IEnumerable<Cart>> GetCartsByStatusTrue();
        public Task<IEnumerable<Cart>> GetCartsByStatusFalse();
        public Task<IEnumerable<Cart>> GetCartsByUserId(string userId);
        public Task<IEnumerable<Cart>> AdvancedSearch(string userId, bool status);
        public Task<bool> CreateAsync(string userId);
        public Task<bool> UpdateAsync(string cartId,string userId);
        public Task<bool> DeleteAsync(string cartId, string userId);
    }
}
