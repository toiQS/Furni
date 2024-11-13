using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;
namespace furni.Infrastructure.Services
{
    public class CartServices(ApplicationDbContext context) : RepositoryAsync<Cart>(context), ICartServices
    {
        public async Task<Cart> GetByIdAsync(string id)
        {
            return await Table
                .Where(cart => cart.Id == id)
                .Include(c => c.CartDetails)
                .ThenInclude(cd => cd.Product)
                .FirstAsync();
        }

        public async Task<Cart> GetByUserIdAsync(string userId)
        {
            return await Table.Where(cart => cart.UserId == userId).Include(c => c.CartDetails).FirstAsync();
        }
    }
}
