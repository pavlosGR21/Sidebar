using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Xml.Linq;
using Sidebar.Dtos;
using Sidebar.Models.JointTables;


namespace Sidebar.Models
{
    public class Exam 
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Assessment Test Code")]
        public string AssessmentTestCode { get; set; }

        [Required]
        [Display(Name = "Examination Date")]        
        public DateTime ExaminationDate { get; set; }


        [Display(Name = "Score Report Date")]
        [Column(TypeName = "Date")]
        public DateTime? ScoreReportDate { get; set; }


        [Display(Name = "Candidate Score")]
        public int? CandidateScore { get; set; }

 
        [Display(Name = "Percentage Score")]
        public string? PercentageScore { get; set; }

   
        [Display(Name = "Assessment Result Label")]
        public string? AssessmentResultLabel { get; set; }

        //public Exam() {

        //}

        //public Exam(string assessmentTestCode, Certificate certificate, Candidate candidate) {
        //    AssessmentTestCode = assessmentTestCode;
        //    Candidate = candidate;
        //    Certificate = certificate;
        //}




        // Navigation Properties

        public virtual Certificate Certificate { get; set; }
        public virtual Candidate Candidate { get; set; }        
        public virtual ICollection<ExamStem>? ExamStems { get; set; }
    }
   
}
