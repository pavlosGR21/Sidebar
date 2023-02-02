using Sidebar.Models;

namespace Sidebar.Dtos {
    public class ExamCreateDTO {
        public string assessmentTestCode { get; set; }
        public int CertificateId { get; set; }
        public int CandidateId { get; set; }
    }
}
