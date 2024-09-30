using Furni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.member
{
    public interface IMemberServices
    {
        public Task<IEnumerable<Member>> GetMembersAsync();
        public Task<IEnumerable<Member>> GetMembersByTextAsync(string text);
        public Task<Member> GetMemberById(string memberId);
        public Task<bool> CreateAsync(string firstName, string? middleName, string lastName, string position, string summary, string urlImage);
        public Task<bool> UpdateAsync(string memberId, string fistName, string? middleName, string lastName, string position, string summary, string urlImage);
        public Task<bool> UpdateAsync(string memberId);
        public Task<bool> DeleteAsync(string memberId);
    }
}
