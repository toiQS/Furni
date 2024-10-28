using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
namespace furni.Infrastructure.Services
{
    public class CartDetailServices (ApplicationDbContext context) : RepositoryAsync<CartDetail>(context), ICartDetailServices{}
}