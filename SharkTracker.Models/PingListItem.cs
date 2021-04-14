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
    public class PingListItem
    {
        public int PingId { get; set; }

       
        public string PingLocation { get; set; }

        [ForeignKey(nameof(tag))]
        public int TagNumber { get; set; }
        public virtual Tag tag { get; set; }

        [ForeignKey(nameof(Shark))]
        public int SharkId { get; set; }
        public string SharkName { get; set; }
        public virtual Shark shark { get; set; }
        public DateTime PingDateTime { get; set; }
    }
}
