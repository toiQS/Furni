using furni.Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace furni.Infrastructure.IServices
{
    public interface IUserServices 
    {
        public Task<User> GetUserByIdAsync(string id);
        public Task<IdentityRole> GetRoleByUserId(string userId);
        public Task<bool> Login(string userName, string password);
        public Task<bool> Register(string userName, string email, string password);
        public Task LogOut();
        //public Task<string> GetUserIdCurrent();
    }
}
