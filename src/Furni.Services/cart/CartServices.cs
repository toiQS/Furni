using Furni.Data;
using Furni.Entities;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furni.Services.cart
{
    public class CartServices : ICartServices
    {
        private readonly ApplicationDbContext _context; // Database context for accessing Cart data
        private readonly string _fileName = "LogCartFile.txt"; // Log file name for error logging
        private readonly string _folderName = "cart"; // Folder name for error logging
        private readonly string _path; // Path for logging errors
        private readonly IRepositoryAsync<Cart> _cartRepository; // Repository for managing Cart entities

        // Constructor for API Controller
        public CartServices(ApplicationDbContext context)
        {
            _context = context;
            _cartRepository = new RepositoryAsync<Cart>(context); // Initialize cart repository

            // Set up log file and folder name
            _cartRepository.GetFileName(_fileName);
            _cartRepository.GetFolderName(_folderName);

            // Get the current path for error logging
            _path = _cartRepository.GetPathFolderCurrent();
        }

        // Fetches all carts asynchronously
        public async Task<IEnumerable<Cart>> GetCartsAsync()
        {
            return await _cartRepository.GetValuesAsync();
        }

        // Fetches a cart by its unique identifier asynchronously
        public async Task<Cart> GetCartByIdAsync(string id)
        {
            try
            {
                return await _context.Cart.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.CartId == id);
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Fetches carts with a status of `true` asynchronously
        public async Task<IEnumerable<Cart>> GetCartsByStatusTrue()
        {
            try
            {
                return await _context.Cart.AsNoTracking()
                    .Where(x => x.Status == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Fetches carts with a status of `false` asynchronously
        public async Task<IEnumerable<Cart>> GetCartsByStatusFalse()
        {
            try
            {
                return await _context.Cart.AsNoTracking()
                    .Where(x => x.Status == false)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Fetches carts by a user's ID asynchronously
        public async Task<IEnumerable<Cart>> GetCartsByUserId(string userId)
        {
            try
            {
                return await _context.Cart.AsNoTracking()
                    .Where(x => x.UserId == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Performs an advanced search for carts by user ID and status asynchronously
        public async Task<IEnumerable<Cart>> AdvancedSearch(string userId, bool status)
        {
            try
            {
                return await _context.Cart.AsNoTracking()
                    .Where(x => x.Status == status && x.UserId == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Creates a new cart for a user asynchronously
        public async Task<bool> CreateAsync(string userId)
        {
            // Check if the user already has an inactive cart
            var hasInactiveCart = await _context.Cart
                .AnyAsync(x => x.UserId == userId && x.Status == false);

            if (hasInactiveCart) return false; // Return false if an inactive cart already exists

            var cart = new Cart()
            {
                UserId = userId,
                CartId = $"1001{DateTime.Now}", // Generate a unique CartId using current date and time
                Status = false, // Default status is inactive
            };

            return await _cartRepository.Create(cart); // Create the new cart
        }

        // Updates the status of a cart asynchronously
        public async Task<bool> UpdateAsync(string cartId, string userId)
        {
            try
            {
                // Fetch the cart by CartId and UserId
                var existingCart = await _context.Cart.AsNoTracking()
                    .Where(x => x.CartId == cartId && x.UserId == userId)
                    .FirstOrDefaultAsync();

                if (existingCart == null) return false; // Return false if cart is not found

                // Toggle the cart status
                existingCart.Status = !existingCart.Status;

                return await _cartRepository.Update(existingCart); // Update the cart
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Deletes a cart by its ID and user ID asynchronously
        public async Task<bool> DeleteAsync(string cartId, string userId)
        {
            try
            {
                // Fetch the cart by CartId and UserId
                var existingCart = await _context.Cart.AsNoTracking()
                    .Where(x => x.UserId == userId && x.CartId == cartId)
                    .FirstOrDefaultAsync();

                if (existingCart == null) return false; // Return false if cart is not found

                return await _cartRepository.Delete(existingCart); // Delete the cart
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _cartRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
    }
}
