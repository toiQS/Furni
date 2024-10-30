using furni.Entities;
using furni.Infrastructure.IServices;
using Microsoft.AspNetCore.Identity;
namespace furni.Infrastructure.IServices
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserServices(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            try
            {
                return await _userManager.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<IdentityRole> GetRoleByUserId(string id)
        {
            try
            {
                return await _roleManager.FindByIdAsync(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}", ex);
                return null;
            }
        }
    }
}
