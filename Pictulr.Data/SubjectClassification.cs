using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Data
{
    internal class SubjectClassification
    {
        [Key]
        [Display(Name = "Subject ID")]
        public int SubjectId { get; set; }

        [Display(Name = "Owner ID")]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Picture Title")]
        public string PictureTitle { get; set; }

        [Required]
        [Display(Name = "Node ID")] //the name of the node that took the pic
        public string NodeNameId { get; set; }

        [Display(Name = "Image Location")]
        public string ImageLocation { get; set; }

        [Display(Name = "Image Data")]
        public string Base64EncodedImage { get; set; }

        [Required]
        [Display(Name = "Time Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Time Recieved")]
        public DateTimeOffset? RecievedUtc { get; set; }

        [Display(Name = "Metadata")]
        public string OptionalMetadata { get; set; }

    }
}
