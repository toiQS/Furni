using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Infrastructure.Services
{
    public class ImageServices(ApplicationDbContext context) : RepositoryAsync<Image>(context), IImageServices
    {
    }
}
