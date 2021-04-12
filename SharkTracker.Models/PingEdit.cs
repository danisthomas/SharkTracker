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

        [Key, Column(Order = 0)]
        public int TagNumber { get; set; }

        [Key, Column(Order = 1)]
        public int SharkId { get; set; }

        public DateTime PingDateTime { get; set; }
    }
}
