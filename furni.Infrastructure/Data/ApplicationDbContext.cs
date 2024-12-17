using furni.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace furni.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<AppUser> User { get; set; }
    public DbSet<Blog> Blog { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Category> Category { get; set; }
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
    public DbSet<Image> Image { get; set; }
    public DbSet<PaymentResponse> PaymentResponse { get; set; }

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


        //builder.Entity<Blog>().HasData
        //    (
        //    new Blog
        //    {
        //        Id = 1,
        //        Name = "Phong Cách Thời Trang Nhanh Từ Zara",
        //        Slug = "phong-cach-thoi-trang-nhanh-tu-zara",
        //        AppUserId = "admin-1",
        //        TopicId = 1,
        //        CreateAt = DateTime.Now,
        //        //Thumbnail = new Image { Url = "zara-thumbnail.jpg" },
        //        Content = "Zara là thương hiệu thời trang nhanh nổi tiếng toàn cầu. Tại Việt Nam, Zara chinh phục khách hàng bằng sự đa dạng trong thiết kế và cập nhật xu hướng mới nhất...",
        //        Description = "Khám phá phong cách thời trang nhanh từ Zara, thương hiệu hàng đầu thế giới.",
        //        IsPublic = true,
        //        IsDeteled = false
        //    },
        //        new Blog
        //        {
        //            Id = 2,
        //            Name = "Uniqlo: Thời Trang Tối Giản Và Chất Lượng",
        //            Slug = "uniqlo-thoi-trang-toi-gian-va-chat-luong",
        //            AppUserId = "admin-1",
        //            TopicId = 2,
        //            CreateAt = DateTime.Now,
        //            //Thumbnail = new Image { ủi = "uniqlo-thumbnail.jpg" },
        //            Content = "Uniqlo nổi bật với phong cách thời trang tối giản, tập trung vào chất liệu thoải mái và bền vững. Đây là lựa chọn hoàn hảo cho những ai yêu thích sự tinh tế và tiện dụng...",
        //            Description = "Phong cách tối giản của Uniqlo đang ngày càng được ưa chuộng tại Việt Nam.",
        //            IsPublic = true,
        //            IsDeteled = false
        //        },
        //        new Blog
        //        {
        //            Id = 3,
        //            Name = "IVY moda: Định Hình Phong Cách Hiện Đại",
        //            Slug = "ivy-moda-dinh-hinh-phong-cach-hien-dai",
        //            AppUserId = "user789",
        //            TopicId = 3,
        //            CreateAt = DateTime.Now,
        //            //Thumbnail = new Image { Url = "ivy-moda-thumbnail.jpg" },
        //            Content = "IVY moda là một trong những thương hiệu thời trang Việt Nam hàng đầu, mang đến sự kết hợp giữa phong cách công sở và street style hiện đại...",
        //            Description = "Khám phá thương hiệu thời trang IVY moda, nơi tôn vinh phong cách cá nhân.",
        //            IsPublic = true,
        //            IsDeteled = false
        //        },
        //        new Blog
        //        {
        //            Id = 4,
        //            Name = "H&M: Thời Trang Cho Mọi Người",
        //            Slug = "hm-thoi-trang-cho-moi-nguoi",
        //            AppUserId = "admin-1",
        //            TopicId = 4,
        //            CreateAt = DateTime.Now,
        //            //Thumbnail = new Image { Url = "hm-thumbnail.jpg" },
        //            Content = "H&M luôn hướng đến việc cung cấp thời trang chất lượng cao với giá cả hợp lý. Các bộ sưu tập của H&M thường được đánh giá cao về tính đa dạng và sự tiện dụng...",
        //            Description = "H&M - nơi thời trang phù hợp với mọi phong cách.",
        //            IsPublic = true,
        //            IsDeteled = false
        //        },
        //        new Blog
        //        {
        //            Id=5,
        //            Name = "Canifa: Thương Hiệu Của Mọi Gia Đình Việt",
        //            Slug = "canifa-thuong-hieu-cua-moi-gia-dinh-viet",
        //            AppUserId = "admin-1",
        //            TopicId = 5,
        //            CreateAt = DateTime.Now,
        //            //Thumbnail = new Image { Url = "canifa-thumbnail.jpg" },
        //            Content = "Canifa là thương hiệu thời trang Việt Nam nổi bật với các sản phẩm len và cotton chất lượng cao. Canifa đáp ứng nhu cầu của mọi thành viên trong gia đình, từ trẻ nhỏ đến người lớn...",
        //            Description = "Canifa - thương hiệu thân thuộc với mọi gia đình Việt Nam.",
        //            IsPublic = true,
        //            IsDeteled = false
        //        }
        //    );
        builder.Entity<Brand>().HasData
            (
            new Brand()
            {
                Id = 1,
                Name = "Canifa",
                IsDeleted = false,
                Products = new List<Product>()
            },
                new Brand()
                {
                    Id= 2,
                    Name = "New Fashion",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Id= 3,
                    Name = "IVY Moda",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Id= 4,
                    Name = "Format",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Id= 5,
                    Name = "Routine",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Id= 6,
                    Name = "K&K Fashion",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                     Id= 7,
                    Name = "Libé",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Id= 8,
                    Name = "BOO ",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Id= 9,
                    Name = "Hnoss Fashion",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand { Id=10, Name = "Adidas", IsDeleted = false, Products = new List<Product>() });
        builder.Entity<Category>().HasData
            (
            new Category()
            {
                Id = 1,
                Name = "Nón",
                IsDeleted = false,
                Products = new List<Product>()
            },
                new Category()
                {
                    Id = 2,
                    Name = "Áo",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Category()
                {
                    Id = 3,
                    Name = "Quần",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Category()
                {
                    Id = 4,
                    Name = "Giày",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Category()
                {
                    Id = 5,
                    Name = "Phụ kiện",
                    IsDeleted = false,
                    Products = new List<Product>()
                });
        builder.Entity<Color>().HasData
            (
            new Color
            {
                Id = 1,
                Name = "Red",
                IsDeleted = false,
                ProductVariants = new List<Variant>()
            },
                new Color
                {
                    Id = 2,
                    Name = "Blue",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                },
                new Color
                {
                    Id = 3,
                    Name = "Black",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                },
                new Color
                {
                    Id = 4,
                    Name = "While",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                },
                new Color
                {
                    Id = 5,
                    Name = "Green",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                });
        builder.Entity<ShippingMethod>().HasData(
             new ShippingMethod { Id = 1, IsDeleted = false, Cost = 10.5, Description = "", Name = "" },
             new ShippingMethod { Id = 2, IsDeleted = false, Cost = 12, Description = "", Name = "" });
        builder.Entity<Size>().HasData
            (
            new Size {Id = 1, Value = "36", IsDeleted = false },
                new Size {Id = 2, Value = "37", IsDeleted = false },
                new Size {Id = 3, Value = "38", IsDeleted = false },
                new Size {Id = 4, Value = "39", IsDeleted = false },
                new Size {Id = 5, Value = "40", IsDeleted = false },
                new Size {Id = 6, Value = "41", IsDeleted = false },
                new Size {Id = 7, Value = "42", IsDeleted = false },
                new Size {Id = 8, Value = "43", IsDeleted = false },
                new Size {Id = 9, Value = "44", IsDeleted = false },
                new Size {Id = 10, Value = "45", IsDeleted = false },
                new Size {Id = 11, Value = "46", IsDeleted = false });
        builder.Entity<Topic>().HasData(
            new Topic {Id =1, Name = "", IsDeleted = false },
                new Topic {Id = 2, Name = "", IsDeleted = false },
                new Topic {Id = 3, Name = "", IsDeleted = false },
                new Topic {Id =4 ,Name = "", IsDeleted = false },
                new Topic {Id = 5, Name = "", IsDeleted = false });
    }
}
