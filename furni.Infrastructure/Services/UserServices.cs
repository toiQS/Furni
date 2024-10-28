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
    }
}