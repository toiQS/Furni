using Furni.Data;
using Furni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.item
{
    public interface IItemServices
    {
        public Task<IEnumerable<Item>> GetItemsAsync();
        public Task<Item> GetItemAsync(string id);
        public Task<IEnumerable<Item>> GetItemByCartId(string cartId);
        public Task<bool> CreateAsync(string productId, int quantity, string cartId);
        public Task<bool> UpdateAsync(string itemId, int quantity);
        public Task<bool> DeleteAsync(string itemId);
    }
}
