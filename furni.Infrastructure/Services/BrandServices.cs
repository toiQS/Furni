using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace furni.Infrastructure.Service
{
    public class BrandServices(ApplicationDbContext context) : RepositoryAsync<Brand>(context),IBrandServices
    {
        private readonly ApplicationDbContext _context;
        // public BrandServices( ApplicationDbContext context )
        // {
        //     _context = context;
        // }
        public async Task<IEnumerable<Brand>> GetBrandsByName(string name)
        {
            try
            {
                return await _context.Brand.Where(x => x.BrandName.ToLower().Contains(name.ToLower())).ToArrayAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Enumerable.Empty<Brand>();
            }
        }
    }
}