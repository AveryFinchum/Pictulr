using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Data
{
    public class Subject
    {
        [Key]
        [Display(Name = "Subject ID")]
        public int SubjectId { get; set; }
        [Required]
        [Display(Name = "Owner ID")]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
        [Required]
        [Display(Name = "Time Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
