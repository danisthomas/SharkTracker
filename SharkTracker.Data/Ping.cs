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

        [ForeignKey(nameof(sharkTag)), Required]
        public int SharkTagId { get; set; }
        public virtual SharkTag sharkTag { get; set; }
        
        
        [Required]
        public DateTime PingDate { get; set; }

        
    }
}
