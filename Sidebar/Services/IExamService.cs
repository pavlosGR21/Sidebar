using Sidebar.Dtos;
using Sidebar.Models;


namespace Sidebar.Services
{
    public interface IExamService : IGenericService<ExamDto>
    {
        new Task<IEnumerable<ExamDto>?> GetAll();
        new Task<MyDTO> AddOrUpdate(int id, ExamDto examDto);
    }
}
