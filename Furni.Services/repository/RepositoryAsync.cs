using Furni.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private string _fileName = string.Empty;
        private string _folderName = string.Empty;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        private string _path = string.Empty;
        public RepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetValuesAsync()
        {
            try
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                await LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> Create(T entity)
        {
            if(entity == null) return false;
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                await LogErrorAsync(_path, ex);
                throw;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            if (entity == null) return false;
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> Update(T entity)
        {
            if (entity == null || entity.GetType() != typeof(T)) return false;
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await LogErrorAsync(_path, ex);
                throw;
            }
        }
        public string GetPathFolderCurrent()
        {
            var assemblyLocation = Assembly.GetEntryAssembly().Location;
            var currentDirectory = Path.GetDirectoryName(assemblyLocation);
            var appRootFolder = currentDirectory.Split("\\bin")[0];
            _path = Path.Combine($"{appRootFolder}", $"{_folderName}", $"{_fileName}");
            return _path;
        }
        public string GetFolderName(string folderName)
        {
            return _folderName = folderName;
        }
        public string GetFileName(string fileName)
        {
            return _folderName = fileName;
        }
        public async Task LogErrorAsync(string path, Exception ex)
        {
            var errorDetails = new StringBuilder();
            errorDetails.AppendLine($"path: {path}\n");
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
