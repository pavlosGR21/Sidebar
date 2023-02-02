using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sidebar.Models;

namespace Sidebar.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>?> GetAllAsync();
        EntityState AddOrUpdate(T item);        
        void Delete(T item);
        Task<bool> Exists(int id);        
    }
}
