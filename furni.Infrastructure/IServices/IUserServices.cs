using furni.Entities;
using Microsoft.AspNetCore.Identity;
namespace furni.Infrastructure.IServices
{
    public interface IUserServices 
    {
        public Task<User> GetUserByIdAsync(string id);
        public Task<IdentityRole> GetRoleByUserId(string userId);
    }
}