using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Models
{
    public class ListPictureClassification
    {
        [Key]
        [Display(Name = "Classification ID")]
        public int ClassificationId { get; set; }
        [Display(Name = "Picture Title")]
        public string PictureTitle { get; set; }
        [Required]
        public string Classification { get; set; }
        [Display(Name = "Node ID")] //the name of the node that took the pic
        public string NodeNameId { get; set; }
        [Display(Name = "Classification Method")]
        public string ClassificationMethod { get; set; }
        [Display(Name = "Processig Time")]
        public TimeSpan ReportTimeDuration { get; set; }
        [Display(Name = "Time Recieved")]
        public DateTimeOffset ReportTimeUtc { get; set; }
    }
}
