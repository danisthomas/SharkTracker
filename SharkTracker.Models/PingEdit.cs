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
    public class PingEdit
    {
        public int PingId { get; set; }
       
        public string PingLocation { get; set; }

        [ForeignKey(nameof(sharkTag))]
        public int SharkTagId { get; set; }
        public virtual SharkTag sharkTag { get; set; }
        public DateTime PingDate { get; set; }
    }
}
