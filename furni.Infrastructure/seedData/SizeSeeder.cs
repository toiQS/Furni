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
    public static class SizeSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Size.Any()) return;
            context.Size.AddRange(
                new Size { Value = "36", IsDeleted = false },
                new Size { Value = "37", IsDeleted = false },
                new Size { Value = "38", IsDeleted = false },
                new Size { Value = "39", IsDeleted = false },
                new Size { Value = "40", IsDeleted = false },
                new Size { Value = "41", IsDeleted = false },
                new Size { Value = "42", IsDeleted = false },
                new Size { Value = "43", IsDeleted = false },
                new Size { Value = "44", IsDeleted = false },
                new Size { Value = "45", IsDeleted = false },
                new Size { Value = "46", IsDeleted = false }
            );
            context.SaveChanges();
        }
    }
}
