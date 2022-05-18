using Pictulr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Models
{
    public class ListSubjects
    {
        [Display(Name = "Subject ID")]
        [ForeignKey(nameof(Subject))]
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public string PictureTitle { get; set; }
        [Display(Name = "Time Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
