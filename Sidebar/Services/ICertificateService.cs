using Sidebar.Models;

namespace Sidebar.Services
{
    public interface ICertificateService : IGenericService<Certificate>
    {
        new Task<IEnumerable<Certificate>?> GetAll();
        new Task<MyDTO> AddOrUpdate(int id, Certificate certificate);        
    }
}