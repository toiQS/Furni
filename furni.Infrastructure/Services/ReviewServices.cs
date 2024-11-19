using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class ReviewServices(ApplicationDbContext context) : RepositoryAsync<Review>(context), IReviewServices { }
}
