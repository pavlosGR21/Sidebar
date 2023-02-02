using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Sidebar.Models.JointTables;
using Sidebar.Models;

namespace Sidebar.Dtos
{
    public class TopicCreateDto
    {
        //TODO Remove this property

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number Of Possible Marks")]
        public int NumberOfPossibleMarks { get; set; }

        [Required]
        [Display(Name = "Certificate ID")]
        public int CertificateID { get; set; }

    }
}
