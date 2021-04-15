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
    public class PingCreate
    {
        public int PingId { get; set; }

        [Required,Display(Name ="Ping Location")]
        public string PingLocation { get; set; }
        
        [Required,Display(Name ="Ping Date and Time")]
        public DateTime PingDateTime { get; set; }

        [ForeignKey(nameof(sharkTag)), Required]
        public int SharkTagId { get; set; }
        public virtual SharkTag sharkTag { get; set; }

    }
}
