using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Data
{
    internal class PictureClassification
    {
        [Key]
        [Display(Name = "Classification ID")]
        public int ClassificationId { get; set; }
        [Required]
        [Display(Name = "Picture Title")]
        [ForeignKey("PictureTitle")]
        public string PictureTitle { get; set; }
        [Required]
        public virtual ICollection<SubjectClassification> Classifications { get; set; }
        public string Classification { get; set; }
        [Required]
        [Display(Name = "Node ID")] //the name of the node that took the pic
        [ForeignKey("NodeNameId")]
        public string NodeNameId { get; set; }
        [Display(Name = "Classification Method")]
        public string ClassificationMethod { get; set; }
        [Required]
        [Display(Name = "Processig Time")]
        public TimeSpan ReportTimeDuration { get; set; }
        [Display(Name = "Time Recieved")]
        public DateTimeOffset ReportTimeUtc { get; set; }
        
    }
}
