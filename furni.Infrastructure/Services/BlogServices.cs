using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
namespace furni.Infrastructure.Services
{
    public class BlogServices(ApplicationDbContext context) :RepositoryAsync<Blog>(context), IBlogServices
    {
        
    }
}