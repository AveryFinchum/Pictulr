using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Data
{
    public class Picture
    {
        [Key]
        [Display(Name ="Picture ID")]
        public int PictureId { get; set; }
        [Required]
        [Display(Name ="Owner ID")]
        public Guid OwnerId { get; set; }

        [Display(Name = "Subject Name")]
        [ForeignKey(nameof(Subject))]
        public int? SubjectName { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        [Display(Name ="Picture Title")]
        public string PictureTitle { get; set; }

        [Display(Name ="Node ID")] //the name of the node that took the pic
        [ForeignKey( nameof(Node))] 
        public int? NodeNameId { get; set; }
        public virtual Node Node { get; set; }


        [Display(Name ="Image Location")]
        public string ImageLocation { get; set; }
        [Display(Name ="Image Data")]
        public string Base64EncodedImage { get; set; }
        [Required]
        [Display(Name ="Time Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Time Recieved")]
        public DateTimeOffset? RecievedUtc { get; set; }
        [Display(Name ="Metadata")]
        public string OptionalMetadata { get; set; }
    }
}
