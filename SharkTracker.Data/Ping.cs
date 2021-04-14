using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Data
{
    public class Ping
    {
        [Key]
        public int PingId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string PingLocation { get; set; }

        [ForeignKey(nameof(tag)), Required]
        public int TagNumber { get; set; }
        public virtual Tag tag { get; set; }
        
        [ForeignKey(nameof(shark)), Required]
        public int SharkId { get; set; }
        public virtual Shark shark { get; set; }

        [Required]
        public DateTime PingDateTime { get; set; }

        //public virtual ICollection<Shark> sharks { get; set; }

       // public virtual ICollection<Tag> tags { get; set; }
    }
}
