using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sidebar.Dtos;
using Sidebar.Models.JointTables;


namespace Sidebar.Models
{
    public class Topic {
        [Key]
        [Required]
        [Display(Name ="Topic Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number Of Possible Marks")]
        public int NumberOfPossibleMarks { get; set; }

        public Topic() {

        }

        public Topic(TopicCreateDto topicDto, Certificate certificate) {
            this.Description = topicDto.Description;
            this.NumberOfPossibleMarks = topicDto.NumberOfPossibleMarks;
            this.Certificate = certificate;
        }
        // Navigation Properties

        public virtual Certificate Certificate { get; set; }        
        public virtual ICollection<Stem>? Stems { get; set; }        
    }
}
