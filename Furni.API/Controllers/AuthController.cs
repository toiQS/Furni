using Furni.API.Models;
using Furni.Services.auth;
using Microsoft.AspNetCore.Mvc;

namespace Furni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        // Constructor injection for IAuthServices
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        /// <summary>
        /// Registers a new user with the "User" role
        /// </summary>
        /// <param name="userName">Username for the new user</param>
        /// <param name="email">Email for the new user</param>
        /// <param name="password">Password for the new user</param>
        /// <returns>Result of the registration process</returns>
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(string userName, string email, string password)
        {
            // Validate input data
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest(ServiceResult<string>.FailureResult("Data input was null or invalid"));

            // Attempt to register the user
            var result = await _authServices.RegisterUser(userName, email, password);
            if (result)
                return Ok(ServiceResult<string>.SuccessResult("Success"));

            return BadRequest(ServiceResult<string>.FailureResult("Can't create new user"));
        }

        /// <summary>
        /// Registers a new manager with the "Manager" role
        /// </summary>
        /// <param name="userName">Username for the new manager</param>
        /// <param name="memberId">Member ID associated with the manager</param>
        /// <param name="email">Email for the new manager</param>
        /// <param name="password">Password for the new manager</param>
        /// <returns>Result of the registration process</returns>
        [HttpPost("RegisterManager")]
        public async Task<IActionResult> RegisterManager(string userName, string memberId, string email, string password)
        {
            // Validate input data
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(memberId) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest(ServiceResult<string>.FailureResult("Data input was null or invalid"));

            // Attempt to register the manager
            var result = await _authServices.RegisterManager(userName, memberId, email, password);
            if (result)
                return Ok(ServiceResult<string>.SuccessResult("Success"));

            return BadRequest(ServiceResult<string>.FailureResult("Can't create new manager"));
        }

        /// <summary>
        /// Registers a new member with the "Member" role
        /// </summary>
        /// <param name="userName">Username for the new member</param>
        /// <param name="memberId">Member ID associated with the member</param>
        /// <param name="email">Email for the new member</param>
        /// <param name="password">Password for the new member</param>
        /// <returns>Result of the registration process</returns>
        [HttpPost("RegisterMember")]
        public async Task<IActionResult> RegisterMember(string userName, string memberId, string email, string password)
        {
            // Validate input data
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(memberId) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest(ServiceResult<string>.FailureResult("Data input was null or invalid"));

            // Attempt to register the member
            var result = await _authServices.RegisterMember(userName, memberId, email, password);
            if (result)
                return Ok(ServiceResult<string>.SuccessResult("Success"));

            return BadRequest(ServiceResult<string>.FailureResult("Can't create new member"));
        }

        /// <summary>
        /// Logs in a user with their email and password
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>Result of the login process</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Validate input data
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest(ServiceResult<string>.FailureResult("Data input was null or invalid"));

            // Attempt to log the user in
            var result = await _authServices.Login(email, password);
            if (result)
                return Ok(ServiceResult<string>.SuccessResult("Success"));

            return BadRequest(ServiceResult<string>.FailureResult("Can't login"));
        }
    }
}
