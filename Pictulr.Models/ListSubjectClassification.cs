using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Models
{
    public class ListSubjectClassification
    {
        [Display(Name = "Classification ID")]
        public int ClassificationId { get; set; }
        [Display(Name = "Subject Name")]
        public int SubjectName { get; set; }
        [Display(Name = "Classification")]
        public string Classification { get; set; }
        [Display(Name = "Node ID")] //the name of the node that took the pic
        public string NodeNameId { get; set; }
        [Display(Name = "Time")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
