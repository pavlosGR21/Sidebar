using Microsoft.AspNetCore.Mvc;
using Sidebar.Dtos;

namespace Sidebar.Models
{
    public class MyDTO
    {
        public string? View { get; set; }
        public string? Message { get; set; }
        public Candidate? Candidate { get; set; }
        public IEnumerable<Candidate>? Candidates { get; set;}
        public Certificate? Certificate { get; set; }
        public IEnumerable<Certificate>? Certificates { get; set;}
        public StemDto? StemDto { get; set; }
        public IEnumerable<StemDto>? StemDtos { get; set; }
        public TopicDto? TopicDto { get; set; }
        public IEnumerable<TopicDto>? TopicDtos { get; set; }
        public ExamDto? ExamDto { get; set; }
        public IEnumerable<ExamDto>? ExamDtos { get; set; }

    }
}
