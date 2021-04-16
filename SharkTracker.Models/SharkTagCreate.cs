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
    public class SharkTagCreate
    {
       

        [Required, Display(Name ="Date Tag Placed")]
        public DateTimeOffset StartDate { get; set; }

        [ForeignKey(nameof(shark)),Required]
        public int SharkId { get; set; }
        public virtual Shark shark { get; set; }

        [ForeignKey(nameof(tag)),Required]
        public int TagId { get; set; }
        public virtual Tag tag { get; set; }

        [ForeignKey(nameof(location)),Required]
        public int LocationId { get; set; }
        public virtual Location location { get; set; }

    }
}
