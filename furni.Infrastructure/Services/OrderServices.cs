using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Services;
namespace furni.Infrastructure.Service
{
    public class OrderServices(ApplicationDbContext context): RepositoryAsync<Order>(context), IOrderServices{}
}