using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Node:
/// data on the nodes that take or process images
/// </summary>
namespace Pictulr.Data
{
    public class Node
    {
        [Key]
        [Display(Name = "Node ID")]
        public int NodeId { get; set; }
        [Display(Name = "Owner ID")]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Node Name ID")] //the name of the node that took the pic
        public string NodeNameId { get; set; }
        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }
        [Display(Name = "Classification Technique/Mode")]
        public string ClassificationTechnique { get; set; }
        [Display(Name = "Time Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
