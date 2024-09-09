using Furni.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.auth
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private string _path;

        // Constants for roles
        private const string UserRole = "User";
        private const string ManagerRole = "Manager";
        private const string MemberRole = "Member";

        public AuthServices(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _path = GetPathFolderCurrent();
        }

        public async Task<bool> RegisterUser(string userName, string email, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = userName,
            };
            return await RegisterUserWithRole(user, password, UserRole);
        }

        public async Task<bool> RegisterManager(string userName, string memberId, string email, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = userName,
                MemberId = memberId,
            };
            return await RegisterUserWithRole(user, password, ManagerRole);
        }

        public async Task<bool> RegisterMember(string userName, string memberId, string email, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = userName,
                MemberId = memberId,
            };
            return await RegisterUserWithRole(user, password, MemberRole);
        }

        private async Task<bool> RegisterUserWithRole(User user, string password, string role)
        {
            try
            {
                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, role);
                return true;
            }
            catch (Exception ex)
            {
                await LogErrorAsync(_path, ex);
                throw;
            }
        }

        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var identityUser = await _userManager.FindByEmailAsync(email); // Corrected from FindByIdAsync
                if (identityUser == null)
                {
                    return false;
                }

                var result = await _signInManager.CheckPasswordSignInAsync(identityUser, password, false);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                await LogErrorAsync(_path, ex);
                throw;
            }
        }

        public string GetPathFolderCurrent()
        {
            var assemblyLocation = Assembly.GetEntryAssembly()?.Location;
            var currentDirectory = Path.GetDirectoryName(assemblyLocation);
            var appRootFolder = currentDirectory?.Split("\\bin")[0];
            _path = Path.Combine(appRootFolder ?? string.Empty, "auth", "LogAuthFile.txt");
            return _path;
        }

        public async Task LogErrorAsync(string path, Exception ex)
        {
            var errorDetails = new StringBuilder();
            errorDetails.AppendLine($"Path: {path}\n");
            errorDetails.AppendLine($"Message: {ex.Message}\n");
            errorDetails.AppendLine($"Stack Trace: {ex.StackTrace}\n");
            errorDetails.AppendLine($"Source: {ex.Source}\n");
            errorDetails.AppendLine($"Time: {DateTime.Now}\n");

            if (!string.IsNullOrEmpty(path))
            {
                await File.AppendAllTextAsync(path, errorDetails.ToString());
            }
        }
    }
}
