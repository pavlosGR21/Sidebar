using Sidebar.Dtos;
using Sidebar.Models;

namespace Sidebar.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<MyDTO> Get(int id);
        Task<IEnumerable<T>?> GetAll();
        Task<MyDTO> GetForUpdate(int id);
        Task<MyDTO> AddOrUpdate(int id, T item);
        Task<MyDTO> GetForDelete(int id);
        Task<MyDTO> Delete(int id);
    }
}
