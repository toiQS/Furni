using Furni.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.auth
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private string _path;

        // Constants for roles
        private const string UserRole = "User";
        private const string ManagerRole = "Manager";
        private const string MemberRole = "Member";

        public AuthServices(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _path = GetPathFolderCurrent();
            _configuration = configuration;
        }

        /// <summary>
        /// Registers a user with the "User" role.
        /// </summary>
        public async Task<bool> RegisterUser(string userName, string email, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = userName,
            };
            return await RegisterUserWithRole(user, password, UserRole);
        }

        /// <summary>
        /// Registers a manager with the "Manager" role.
        /// </summary>
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

        /// <summary>
        /// Registers a member with the "Member" role.
        /// </summary>
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

        /// <summary>
        /// Registers a user and assigns a role.
        /// </summary>
        private async Task<bool> RegisterUserWithRole(User user, string password, string role)
        {
            try
            {
                // Create the user and assign the role
                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, role);
                return true;
            }
            catch (Exception ex)
            {
                // Log the error to a file
                await LogErrorAsync(_path, ex);
                return false;
            }
        }

        /// <summary>
        /// Logs in a user by checking email and password.
        /// </summary>
        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var identityUser = await _userManager.FindByEmailAsync(email);
                if (identityUser == null)
                {
                    return false;
                }

                var result = await _signInManager.CheckPasswordSignInAsync(identityUser, password, false);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur
                await LogErrorAsync(_path, ex);
                return false;
            }
        }

        /// <summary>
        /// Generates the path for logging authentication errors.
        /// </summary>
        public string GetPathFolderCurrent()
        {
            var assemblyLocation = Assembly.GetEntryAssembly()?.Location;
            var currentDirectory = Path.GetDirectoryName(assemblyLocation);
            var appRootFolder = currentDirectory?.Split("\\bin")[0];
            _path = Path.Combine(appRootFolder ?? string.Empty, "auth", "LogAuthFile.txt");
            return _path;
        }

        /// <summary>
        /// Logs error details to a file.
        /// </summary>
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

        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        public async Task<string> GennerateTokenString(string email, string password)
        {
            var identityUser = await _userManager.FindByEmailAsync(email);
            if (identityUser == null)
            {
                return "false";
            }

            var role = await _userManager.GetRolesAsync(identityUser);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role[0])
            };

            // Create security key and signing credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Define the JWT token options
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            // Generate and return the JWT token
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
