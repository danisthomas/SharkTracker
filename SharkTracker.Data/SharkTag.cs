using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Data
{
    public class SharkTag
    {
        [Key]
        public int SharkTagId { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }


        public DateTimeOffset? EndDate { get; set; }

        [ForeignKey(nameof(shark))]
        public int SharkId { get; set; }
        public virtual Shark shark { get; set; }

        [ForeignKey(nameof(tag))]
        public int TagId { get; set; }
        public virtual Tag tag { get; set; }

        [ForeignKey(nameof(location))]
        public int LocationId { get; set; }
        public virtual Location location { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

    }
}
