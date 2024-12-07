using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace furni.Infrastructure.seedData
{
    public static  class ImageSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Image.Any()) return;
            context.Image.AddRange(
                new Image()
                {
                    Name = "",
                },
                new Image()
                {
                    Name = ""
                },
                new Image()
                {
                    Name = ""
                });
            context.SaveChanges();
        }
    }
}
