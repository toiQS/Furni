using Furni.Data;
using Furni.Entities;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furni.Services.member
{
    public class MemberServices : IMemberServices
    {
        private readonly ApplicationDbContext _context; // Database context
        private readonly IRepositoryAsync<Member> _repositoryMember; // Repository for managing Member entities
        private readonly string _path; // Path for logging errors
        private readonly string _fileName = "LogMemberFile.txt"; // Log file name for error logging
        private readonly string _folderName = "member"; // Folder name for error logging

        // Constructor for the service, initializing the repository and logging setup
        public MemberServices(ApplicationDbContext context)
        {
            _context = context;
            _repositoryMember = new RepositoryAsync<Member>(context);
            _repositoryMember.GetFileName(_fileName);
            _repositoryMember.GetFolderName(_folderName);
            _path = _repositoryMember.GetPathFolderCurrent();
        }

        // Fetches all members asynchronously
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _repositoryMember.GetValuesAsync();
        }

        // Fetches members by searching for a text in their names (case-insensitive)
        public async Task<IEnumerable<Member>> GetMembersByTextAsync(string text)
        {
            try
            {
                // Searching for text in the FirstName, MiddleName, or LastName
                return await _context.Member.AsNoTracking()
                    .Where(x => x.FirstName.ToLower().Contains(text.ToLower()) ||
                                x.MiddleName.ToLower().Contains(text.ToLower()) ||
                                x.LastName.ToLower().Contains(text.ToLower()))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the error and rethrow the exception
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Fetches a specific member by their ID
        public async Task<Member> GetMemberById(string memberId)
        {
            try
            {
                return await _context.Member.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.MemberId == memberId);
            }
            catch (Exception ex)
            {
                // Log the error and rethrow the exception
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Creates a new member entity and saves it to the database
        public async Task<bool> CreateAsync(string firstName, string? middleName, string lastName, string position, string summary, string urlImage)
        {
            try
            {
                var member = new Member()
                {
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    FullName = $"{firstName} {middleName ?? string.Empty} {lastName}", // Build full name dynamically
                    Position = position,
                    Summary = summary,
                    URLImage = urlImage,
                    MemberId = $"1211{DateTime.Now.Ticks}", // Generate a unique MemberId using current timestamp
                    IsDeleted = false
                };

                return await _repositoryMember.Create(member);
            }
            catch (Exception ex)
            {
                // Log the error and rethrow the exception
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Updates an existing member entity
        public async Task<bool> UpdateAsync(string memberId, string firstName, string? middleName, string lastName, string position, string summary, string urlImage)
        {
            try
            {
                // Fetch the member entity by their ID
                var member = await _context.Member.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.MemberId == memberId);

                if (member == null)
                    return false; // Return false if the member is not found

                // Update member fields
                member.FirstName = firstName;
                member.MiddleName = middleName;
                member.LastName = lastName;
                member.FullName = $"{firstName} {middleName ?? string.Empty} {lastName}";
                member.Position = position;
                member.Summary = summary;
                member.URLImage = urlImage;

                // Update the member in the repository
                return await _repositoryMember.Update(member);
            }
            catch (Exception ex)
            {
                // Log the error and rethrow the exception
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Toggles the IsDeleted status of a member
        public async Task<bool> UpdateAsync(string memberId)
        {
            try
            {
                // Fetch the member by their ID
                var member = await _context.Member.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.MemberId == memberId);

                if (member == null)
                    return false; // Return false if the member is not found

                // Toggle the IsDeleted status
                member.IsDeleted = !member.IsDeleted;

                // Update the member in the repository
                return await _repositoryMember.Update(member);
            }
            catch (Exception ex)
            {
                // Log the error and rethrow the exception
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Deletes a member by their ID
        public async Task<bool> DeleteAsync(string memberId)
        {
            try
            {
                // Fetch the member entity by their ID
                var member = await _context.Member.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.MemberId == memberId);

                if (member == null)
                    return false; // Return false if the member is not found

                // Delete the member in the repository
                return await _repositoryMember.Delete(member);
            }
            catch (Exception ex)
            {
                // Log the error and rethrow the exception
                await _repositoryMember.LogErrorAsync(_path, ex);
                throw;
            }
        }
    }
}
