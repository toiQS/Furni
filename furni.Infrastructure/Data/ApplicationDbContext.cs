using furni.Entities;
using Microsoft.EntityFrameworkCore;

namespace furni.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
