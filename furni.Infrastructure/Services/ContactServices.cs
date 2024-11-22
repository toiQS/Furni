using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class ContactServices(ApplicationDbContext context) : RepositoryAsync<Contact>(context), IContactServices { }
}
