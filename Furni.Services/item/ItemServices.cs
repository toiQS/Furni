using Furni.Data;
using Furni.Entities;
using Furni.Services.cart;
using Furni.Services.product;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furni.Services.item
{
    public class ItemServices : IItemServices
    {
        private readonly ApplicationDbContext _context; // Database context
        private readonly IRepositoryAsync<Item> _repository; // Repository for managing Item entities
        private readonly IProductServices _productServices; // Product services for checking products
        private readonly ICartServices _cartServices; // Cart services for managing carts
        private readonly string _path; // Path for logging errors
        private readonly string _fileName = "LogItemFile.txt"; // Log file name for error logging
        private readonly string _folderName = "item"; // Folder name for error logging

        // Constructor for API controller
        public ItemServices(ApplicationDbContext context)
        {
            _context = context;
            _repository = new RepositoryAsync<Item>(context); // Initialize item repository
            _repository.GetFileName(_fileName);
            _repository.GetFolderName(_folderName);
            _path = _repository.GetPathFolderCurrent(); // Set the current path for logging

            _productServices = new ProductServices(context); // Initialize product services
            _cartServices = new CartServices(context); // Initialize cart services
        }

        // Fetches all items asynchronously
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _repository.GetValuesAsync();
        }

        // Fetches a specific item by its ID asynchronously
        public async Task<Item> GetItemAsync(string id)
        {
            try
            {
                return await _context.Item.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ItemId == id);
            }
            catch (Exception ex)
            {
                // Log the error in case of an exception
                await _repository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Fetches items by CartId asynchronously
        public async Task<IEnumerable<Item>> GetItemByCartId(string cartId)
        {
            try
            {
                return await _context.Item.AsNoTracking()
                    .Where(x => x.CartId == cartId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the error in case of an exception
                await _repository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Creates a new item asynchronously, linking it with a product and cart
        public async Task<bool> CreateAsync(string productId, int quantity, string cartId)
        {
            try
            {
                // Check if the product and cart exist
                var product = await _productServices.GetProductById(productId);
                var cart = await _cartServices.GetCartByIdAsync(cartId);

                // Return false if either the product or cart is not found
                if (product == null || cart == null) return false;

                // Create a new item
                var item = new Item()
                {
                    CartId = cartId,
                    Quantity = quantity,
                    ProductId = productId,
                    Price = product.Price,
                    ItemId = $"item{DateTime.Now}", // Unique item ID based on current date
                    Total = quantity * product.Price, // Calculate total price based on quantity
                };

                // Save the new item to the repository
                return await _repository.Create(item);
            }
            catch (Exception ex)
            {
                // Log the error in case of an exception
                await _repository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Updates the quantity of an existing item asynchronously
        public async Task<bool> UpdateAsync(string itemId, int quantity)
        {
            try
            {
                // Fetch the item by its ID
                var item = await _context.Item.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ItemId == itemId);

                // Return false if the item is not found
                if (item == null) return false;

                // Update the item's quantity and recalculate the total price
                item.Quantity = quantity;
                item.Total = quantity * item.Price;

                // Update the item in the repository
                return await _repository.Update(item);
            }
            catch (Exception ex)
            {
                // Log the error in case of an exception
                await _repository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Deletes an item by its ID asynchronously
        public async Task<bool> DeleteAsync(string itemId)
        {
            try
            {
                // Fetch the item by its ID
                var item = await _context.Item.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ItemId == itemId);

                // Return false if the item is not found
                if (item == null) return false;

                // Delete the item from the repository
                return await _repository.Delete(item);
            }
            catch (Exception ex)
            {
                // Log the error in case of an exception
                await _repository.LogErrorAsync(_path, ex);
                throw;
            }
        }
    }
}
