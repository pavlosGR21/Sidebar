using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using Sidebar.Models.JointTables;


namespace Sidebar.Models
{
    public class Candidate {
        //Basic properties for each Candidate

        [Key]
        [Required]
        [Display(Name = "Candidate Number")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Native Language")]
        public string NativeLanguage { get; set; }

        [Required]
        [Display(Name = "Country Of Residence")]
        public string CountryOfResidence { get; set; }

        [Required]
        [Display(Name = "Birthdate")]
        [Column(TypeName = "Date")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Display(Name = "E-mail Αddress")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Landline Phone Number")]
        public string LandlineNumber { get; set; }

        [Required]
        [Display(Name = "Mobile Phone Number")]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string? Address2 { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Town")]
        public string Town { get; set; }

        [Display(Name = "Province")]
        public string? Province { get; set; }

        [Required]
        [Display(Name = "Photo Id Type")]
        public string PhotoIdType { get; set; }

        [Required]
        [Display(Name = "Photo Id Number")]
        public string PhotoIdNumber { get; set; }

        [Required]
        [Display(Name = "Photo Id Date")]
        [Column(TypeName = "Date")]
        public DateTime PhotoIdDate { get; set; }

        
        // Navigation Property        
        public virtual ICollection<CandidateExam>? CandidateExams { get; set; }
    }
}
