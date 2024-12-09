using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Infrastructure.seedData
{
    public static class TopicSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Topic.Any()) return;
            context.Topic.AddRange(
                new Topic { Name = "", IsDeleted =false},
                new Topic { Name = "", IsDeleted =false},
                new Topic { Name = "", IsDeleted =false},
                new Topic { Name = "", IsDeleted =false},
                new Topic { Name = "", IsDeleted =false}
                );
            context.SaveChanges();
        }

    }
}
