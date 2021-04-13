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
        [Required]
        public Guid OwnerId { get; set; }


        public int PingId { get; set; }

        [Required]
        public string PingLocation { get; set; }

        [Key, Column(Order = 0)]
        public int TagNumber { get; set; }

        [Key, Column(Order = 1)]
        public int SharkId { get; set; }


        [Required]
        public DateTime PingDateTime { get; set; }

        public virtual ICollection<Shark> sharks { get; set; }

        public virtual ICollection<Tag> tags { get; set; }
    }
}
