using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace furni.Infrastructure.Service
{
    public class BrandServices(ApplicationDbContext context) : RepositoryAsync<Brand>(context),IBrandServices{}
}