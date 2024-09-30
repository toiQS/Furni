using Furni.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.auth
{
    public interface IAuthServices
    {
        public Task<bool> RegisterUser(string userName, string email, string password);
        public Task<bool> RegisterManager(string userName, string memberId, string email, string password);
        public Task<bool> RegisterMember(string userName, string memberId, string email, string password);
        public Task<bool> Login(string email, string password);
        public Task<string> GennerateTokenString(string email, string password);
    }
}
