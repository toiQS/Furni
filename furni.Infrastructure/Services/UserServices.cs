using furni.Domain.Entities;
using furni.Infrastructure.IServices;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging.Console;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
namespace furni.Infrastructure.IServices
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserServices(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<AppUser> GetUserByIdAsync(string id)
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
        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var identityUser = await _userManager.FindByEmailAsync(email);
                if (identityUser == null) return false;
                var check = await _signInManager.CheckPasswordSignInAsync(identityUser, password,false);
                if (!check.Succeeded) return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
                return false;
            }
        }
        public async Task<bool> Register(string userName, string email, string password)
        {
            try
            {
                var identityUser = new AppUser
                {
                    UserName = userName,
                    Email = email,
                };
                var result = await _userManager.CreateAsync(identityUser, password);
                if (!result.Succeeded) return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
    }
}
