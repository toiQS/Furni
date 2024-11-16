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
            return await Table.Include(c => c.CartDetails).FirstOrDefaultAsync();
        }

    }
}
