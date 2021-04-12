using SharkTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Models
{
   public class TagListItem
    {
        public int TagNumber { get; set; }

        [Required]
        public string TagLocation { get; set; }

        [Required]
        public DateTime TagDate { get; set; }

        [ForeignKey(nameof(shark)), Required]
        public int SharkId { get; set; }
        public virtual Shark shark { get; set; }
    }
}
