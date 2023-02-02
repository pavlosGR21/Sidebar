using Sidebar.Dtos;
using Sidebar.Models;

namespace Sidebar.Services
{
    public interface IStemService : IGenericService<StemDto>
    {
        new Task<IEnumerable<StemDto>?> GetAll();
        new Task<MyDTO> AddOrUpdate(int id, StemDto stemDto);        
    }
}