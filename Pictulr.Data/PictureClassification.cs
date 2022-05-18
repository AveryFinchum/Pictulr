using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Data
{
    public class PictureClassification
    {
        [Key]
        [Display(Name = "Classification ID")]
        public int ClassificationId { get; set; }

        [Display(Name = "Picture ID")]
        [ForeignKey("Picture")]
        public int? PictureID { get; set; }
        public virtual Picture Picture { get; set; }

        [Required]
        public virtual ICollection<SubjectClassification> Classifications { get; set; }
        public string Classification { get; set; }


        [Display(Name = "Node ID")] //the name of the node that took the pic
        [ForeignKey(nameof(Node))]
        public int? NodeNameId { get; set; }
        public virtual Node Node { get; set; }

        [Display(Name = "Classification Method")]
        public string ClassificationMethod { get; set; }
        [Required]
        [Display(Name = "Processig Time")]
        public TimeSpan ReportTimeDuration { get; set; }
        [Display(Name = "Time Recieved")]
        public DateTimeOffset ReportTimeUtc { get; set; }
        
    }
}
