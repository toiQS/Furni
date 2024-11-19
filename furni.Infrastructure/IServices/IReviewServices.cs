using furni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Infrastructure.IServices
{
    public interface IReviewServices : IRepositoryAsync<Review>
    {
    }
}
