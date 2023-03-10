using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Sidebar.Models.JointTables;


namespace Sidebar.Models
{
    public class Stem {
        [Key]
        [Required]
        [Display(Name = "Stem Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string Question { get; set; }

        [Required]
        [Display(Name = "Option A")]
        public string OptionA { get; set; }

        [Required]
        [Display(Name = "Option B")]
        public string OptionB { get; set; }

        [Required]
        [Display(Name = "Option C")]
        public string OptionC { get; set; }

        [Required]
        [Display(Name = "Option D")]
        public string OptionD { get; set; }

        [Required]
        [Display(Name = "Correct Answer")]
        public char CorrectAnswer { get; set; }


        // Navigation Properties

        public virtual Topic Topic { get; set; }
        public virtual ICollection<ExamStem>? ExamStems { get; set; }

    }
}
