using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Services;
namespace furni.Infrastructure.Services
{
    public class CartServices(ApplicationDbContext context) : RepositoryAsync<Cart>(context),ICartServices{}
}