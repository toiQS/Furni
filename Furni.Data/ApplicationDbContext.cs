using Furni.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> User {  get; set; }
        public DbSet<Blog> Blog {  get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Product> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=AKAI;Database=Furni;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
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

            // Seeding Members
            builder.Entity<Member>().HasData(
                new Member { MemberId = "M1", FirstName = "John", LastName = "Doe", MiddleName = "A", FullName = "John A Doe", Position = "Admin", Summary = "Administrator", URLImage = "/images/johndoe.jpg", IsDeleted = false },
                new Member { MemberId = "M2", FirstName = "Jane", LastName = "Doe", MiddleName = "B", FullName = "Jane B Doe", Position = "User", Summary = "Regular user", URLImage = "/images/janedoe.jpg", IsDeleted = false },
                new Member { MemberId = "M3", FirstName = "Alice", LastName = "Johnson", MiddleName = "C", FullName = "Alice C Johnson", Position = "Designer", Summary = "Interior Designer", URLImage = "/images/alice.jpg", IsDeleted = false },
                new Member { MemberId = "M4", FirstName = "Bob", LastName = "Smith", MiddleName = "D", FullName = "Bob D Smith", Position = "Sales", Summary = "Sales Manager", URLImage = "/images/bob.jpg", IsDeleted = false },
                new Member { MemberId = "M5", FirstName = "Eve", LastName = "Taylor", MiddleName = "E", FullName = "Eve E Taylor", Position = "Marketing", Summary = "Marketing Specialist", URLImage = "/images/eve.jpg", IsDeleted = false }
            );

            // Seeding Products
            builder.Entity<Product>().HasData(
                new Product { ProductId = "P1", ProductName = "Sofa", Price = 499.99f, URLImage = "/images/sofa.jpg", IsActive = true },
                new Product { ProductId = "P2", ProductName = "Chair", Price = 79.99f, URLImage = "/images/chair.jpg", IsActive = true },
                new Product { ProductId = "P3", ProductName = "Table", Price = 199.99f, URLImage = "/images/table.jpg", IsActive = true },
                new Product { ProductId = "P4", ProductName = "Lamp", Price = 29.99f, URLImage = "/images/lamp.jpg", IsActive = true },
                new Product { ProductId = "P5", ProductName = "Bookshelf", Price = 149.99f, URLImage = "/images/bookshelf.jpg", IsActive = true }
            );

            // Seeding Carts
            builder.Entity<Cart>().HasData(
                new Cart { CartId = "C1", UserId = "M1", Status = true },
                new Cart { CartId = "C2", UserId = "M2", Status = true },
                new Cart { CartId = "C3", UserId = "M3", Status = true },
                new Cart { CartId = "C4", UserId = "M4", Status = true },
                new Cart { CartId = "C5", UserId = "M5", Status = true }
            );

            // Seeding Items
            builder.Entity<Item>().HasData(
                new Item { ItemId = "I1", ProductId = "P1", Price = 499.99f, Quantity = 1, Total = 499.99f, CartId = "C1" },
                new Item { ItemId = "I2", ProductId = "P2", Price = 79.99f, Quantity = 2, Total = 159.98f, CartId = "C2" },
                new Item { ItemId = "I3", ProductId = "P3", Price = 199.99f, Quantity = 1, Total = 199.99f, CartId = "C3" },
                new Item { ItemId = "I4", ProductId = "P4", Price = 29.99f, Quantity = 3, Total = 89.97f, CartId = "C4" },
                new Item { ItemId = "I5", ProductId = "P5", Price = 149.99f, Quantity = 1, Total = 149.99f, CartId = "C5" }
            );

            // Seeding Blogs
            builder.Entity<Blog>().HasData(
                new Blog { BlogId = "B1", BlogName = "Furniture Tips", UserIdCreated = "M1", CreateAt = DateTime.Now.AddMonths(-1), UpdateAt = DateTime.Now },
                new Blog { BlogId = "B2", BlogName = "Interior Design Ideas", UserIdCreated = "M2", CreateAt = DateTime.Now.AddMonths(-2), UpdateAt = DateTime.Now },
                new Blog { BlogId = "B3", BlogName = "Latest Trends in Furniture", UserIdCreated = "M3", CreateAt = DateTime.Now.AddMonths(-3), UpdateAt = DateTime.Now },
                new Blog { BlogId = "B4", BlogName = "Home Decor Essentials", UserIdCreated = "M4", CreateAt = DateTime.Now.AddMonths(-4), UpdateAt = DateTime.Now },
                new Blog { BlogId = "B5", BlogName = "Choosing the Right Furniture", UserIdCreated = "M5", CreateAt = DateTime.Now.AddMonths(-5), UpdateAt = DateTime.Now }
            );
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override Version SchemaVersion => base.SchemaVersion;
    }
}
