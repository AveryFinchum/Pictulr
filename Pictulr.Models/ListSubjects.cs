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
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

    }
}
