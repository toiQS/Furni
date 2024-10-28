using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Service;
using furni.Infrastructure.Services;
namespace furni.Infrastructure.Service
{
    public class OrderDetailServices(ApplicationDbContext context) : RepositoryAsync<OrderDetail>(context), IOrderDetailServices{}
}