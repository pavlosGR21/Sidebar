using Sidebar.Models;

namespace Sidebar.Services
{
    public interface ICandidateService : IGenericService<Candidate>
    {
        new Task<IEnumerable<Candidate>?> GetAll();
        new Task<MyDTO> AddOrUpdate(int id, Candidate candidate);
    }
}
