using Sidebar.Dtos;
using Sidebar.Models;

namespace Sidebar.Services
{
    internal interface ITopicService : IGenericService<TopicDto>
    {
        new Task<IEnumerable<TopicDto>?> GetAll();
        new Task<MyDTO> AddOrUpdate(int id, TopicDto topicDto);        
    }
}