using Furni.Data;
using Furni.Entities;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Furni.Services.member
{
    public class MemberServices : IMemberServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryAsync<Member> _repositoryMember;
        private string _path = string.Empty, _fileName = "LogMemberFile.txt", _folderName = "member";
        // Constructor for api controller
        public MemberServices(ApplicationDbContext context)
        {
            _context = context;
            _repositoryMember = new RepositoryAsync<Member>(context);
            _repositoryMember.GetFileName(_fileName);
            _repositoryMember.GetFolderName(_folderName);
            _path = _repositoryMember.GetPathFolderCurrent();
        }
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _repositoryMember.GetValuesAsync();
        }
        public async Task<IEnumerable<Member>> GetMembersByTextAsync(string text)
        {
            try
            {
                return await _context.Member.AsNoTracking().Where(x => x.FirstName.ToLower().Contains(text.ToLower()) ||
                                                                        x.FirstName.ToLower().Contains(text.ToLower()) ||
                                                                        x.FirstName.ToLower().Contains(text.ToLower())).ToListAsync();

            }
            catch (Exception ex)
            {
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<Member> GetMemberById(string memberId)
        {
            try
            {
                return await _context.Member.AsNoTracking().FirstOrDefaultAsync(x => x.MemberId == memberId);

            }
            catch (Exception ex)
            {
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> CreateAsync(string firstName, string? middleName, string lastName, string position, string summary, string urlImage)
        {
            var memeber = new Member()
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                FullName = $"{firstName} {middleName??string.Empty} {lastName}",
                IsDeleted = false ,
                MemberId = $"1211{DateTime.Now}",
                Position = position,
                Summary = summary,
                URLImage = urlImage
            };
            return await _repositoryMember.Create(memeber);
        }
        public async Task<bool> UpdateAsync(string memberId, string firstName, string? middleName, string lastName, string position, string summary, string urlImage)
        {
            try
            {
                var data = await _context.Member.AsNoTracking().FirstOrDefaultAsync(x => x.MemberId == memberId);
                if (data == null)
                    return false;
                data.FirstName = firstName;
                data.MiddleName = middleName;
                data.LastName = lastName;
                data.FullName = $"{firstName} {middleName ?? string.Empty} {lastName}";
                data.Position = position;
                data.Summary = summary;
                data.URLImage = urlImage;
                return await _repositoryMember.Update(data);

            }
            catch (Exception ex)
            {
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> UpdateAsync(string memberId)
        {
            try
            {
                var data = await _context.Member.AsNoTracking().FirstOrDefaultAsync(x => x.MemberId == memberId);
                if (data == null)
                    return false;
                data.IsDeleted = !data.IsDeleted;
                return await _repositoryMember.Update(data);
            }
            catch (Exception ex)
            {
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> DeleteAsync(string memberId)
        {
            try
            {
                var data = await _context.Member.AsNoTracking().FirstOrDefaultAsync(x => x.MemberId == memberId);
                if (data == null)
                    return false;
                return await _repositoryMember.Delete(data);
            }
            catch (Exception ex)
            {
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }
    }
}
