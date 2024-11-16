using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
namespace furni.Infrastructure.Services
{
    public class DeliveryInformationServices(ApplicationDbContext context) : RepositoryAsync<DeliveryInformation>(context), IDeliveyInformationServices{}
}