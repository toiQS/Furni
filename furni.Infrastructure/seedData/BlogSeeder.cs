using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Infrastructure.seedData
{
    public static class BlogSeeder
    {
        public static void Initialize( IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if(context.Blog.Any()) return;
            context.Blog.AddRange(
                new Blog
                {
                    Name = "Phong Cách Thời Trang Nhanh Từ Zara",
                    Slug = "phong-cach-thoi-trang-nhanh-tu-zara",
                    AppUserId = "admin-1",
                    TopicId = 1,
                    CreateAt = DateTime.Now,
                    Thumbnail = null,
                    //Thumbnail = new Image { Url = "zara-thumbnail.jpg" },
                    Content = "Zara là thương hiệu thời trang nhanh nổi tiếng toàn cầu. Tại Việt Nam, Zara chinh phục khách hàng bằng sự đa dạng trong thiết kế và cập nhật xu hướng mới nhất...",
                    Description = "Khám phá phong cách thời trang nhanh từ Zara, thương hiệu hàng đầu thế giới.",
                    IsPublic = true,
                    IsDeteled = false
                },
                new Blog
                {
                    Name = "Uniqlo: Thời Trang Tối Giản Và Chất Lượng",
                    Slug = "uniqlo-thoi-trang-toi-gian-va-chat-luong",
                    AppUserId = "admin-1",
                    TopicId = 2,
                    CreateAt = DateTime.Now,
                    Thumbnail = null,
                    Content = "Uniqlo nổi bật với phong cách thời trang tối giản, tập trung vào chất liệu thoải mái và bền vững. Đây là lựa chọn hoàn hảo cho những ai yêu thích sự tinh tế và tiện dụng...",
                    Description = "Phong cách tối giản của Uniqlo đang ngày càng được ưa chuộng tại Việt Nam.",
                    IsPublic = true,
                    IsDeteled = false
                },
                new Blog
                {
                    Name = "IVY moda: Định Hình Phong Cách Hiện Đại",
                    Slug = "ivy-moda-dinh-hinh-phong-cach-hien-dai",
                    AppUserId = "admin-1",
                    TopicId = 3,
                    CreateAt = DateTime.Now,
                    Thumbnail = null,
                    //Thumbnail = new Image { Url = "ivy-moda-thumbnail.jpg" },
                    Content = "IVY moda là một trong những thương hiệu thời trang Việt Nam hàng đầu, mang đến sự kết hợp giữa phong cách công sở và street style hiện đại...",
                    Description = "Khám phá thương hiệu thời trang IVY moda, nơi tôn vinh phong cách cá nhân.",
                    IsPublic = true,
                    IsDeteled = false
                },
                new Blog
                {
                    Name = "H&M: Thời Trang Cho Mọi Người",
                    Slug = "hm-thoi-trang-cho-moi-nguoi",
                    AppUserId = "admin-1",
                    TopicId = 4,
                    CreateAt = DateTime.Now,
                    //Thumbnail = new Image { Url = "hm-thumbnail.jpg" },
                    Thumbnail = null,
                    Content = "H&M luôn hướng đến việc cung cấp thời trang chất lượng cao với giá cả hợp lý. Các bộ sưu tập của H&M thường được đánh giá cao về tính đa dạng và sự tiện dụng...",
                    Description = "H&M - nơi thời trang phù hợp với mọi phong cách.",
                    IsPublic = true,
                    IsDeteled = false
                },
                new Blog
                {
                    Name = "Canifa: Thương Hiệu Của Mọi Gia Đình Việt",
                    Slug = "canifa-thuong-hieu-cua-moi-gia-dinh-viet",
                    AppUserId = "admin-1",
                    TopicId = 5,
                    CreateAt = DateTime.Now,
                    Thumbnail = null,
                    //Thumbnail = new Image { Url = "canifa-thumbnail.jpg" },
                    Content = "Canifa là thương hiệu thời trang Việt Nam nổi bật với các sản phẩm len và cotton chất lượng cao. Canifa đáp ứng nhu cầu của mọi thành viên trong gia đình, từ trẻ nhỏ đến người lớn...",
                    Description = "Canifa - thương hiệu thân thuộc với mọi gia đình Việt Nam.",
                    IsPublic = true,
                    IsDeteled = false
                }


            );
            context.SaveChanges();
        }
    }
}
