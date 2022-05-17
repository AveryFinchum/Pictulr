using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Data
{
    public class SubjectClassification
    {
        [Key]
        [Display(Name = "Classification ID")]
        public int ClassificationId { get; set; }
        
        [Display(Name = "Subject Name")]
        [ForeignKey(nameof(Subject))]
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [Display(Name = "Owner ID")]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Classification")]
        public virtual ICollection<PictureClassification> Classifications { get; set; }
        public string Classification  { get; set; }

        [Display(Name = "Node ID")] //the name of the node that took the pic
        [ForeignKey(nameof(Node))]
        public int? NodeNameId { get; set; }
        public virtual Node Node { get; set; }

        [Required]
        [Display(Name = "Time")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
