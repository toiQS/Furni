using furni.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace furni.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<string>, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<AppUser> User { get; set; }
    public DbSet<Blog> Blog { get; set; }
    //public DbSet<Cart> Cart { get; set; }
    //public DbSet<CartDetail> CartDetail { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Category> Category { get; set; }
    //public DbSet<DeliveryInformation> DeliveryInformation { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<ShippingMethod> ShippingMethod { get; set; }
    public DbSet<Topic> Topic { get; set; }
    public DbSet<Color> Color { get; set; }
    public DbSet<Variant> ProductVariant { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<VariantSize> VariantSize { get; set; }
    public DbSet<Contact> Contact { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove the AspNet prefix from table names
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName != null && tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }

        builder.Entity<Brand>()
            .HasMany(e => e.Products)
            .WithOne(e => e.Brand)
            .HasForeignKey(p => p.BrandId)
            .IsRequired();

        builder.Entity<Category>()
            .HasMany(e => e.Products)
            .WithOne(e => e.Category)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

        //builder.Entity<CartDetail>()
        //    .HasOne(e => e.ProductVariant);

        builder.Entity<OrderDetail>()
            .HasOne(e => e.VariantSize);

        builder.Entity<Order>()
            .HasOne(e => e.Address)
            .WithMany(e => e.Orders)
            .HasForeignKey(p => p.AddressId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
