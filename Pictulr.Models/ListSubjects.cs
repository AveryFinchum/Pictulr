using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictulr.Models
{
    public class ListSubjects
    {
        [Display(Name = "Subject ID")]
        public int SubjectId { get; set; }
        public string PictureTitle { get; set; }
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
        [Display(Name = "Time Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
