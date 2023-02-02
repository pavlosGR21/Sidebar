using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sidebar.Models.JointTables {
    public class CandidateExam 
    {
        public int CandidateExamId { get; set; }     


        // Navigation Properties
        public virtual Candidate Candidate { get; set; }
        public virtual Exam Exam { get; set; }
        
    }
}
