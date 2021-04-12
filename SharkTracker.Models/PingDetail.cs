using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Models
{
    public class PingDetail
    {
        public int PingId { get; set; }

        public string PingLocation { get; set; }

        public int TagNumber { get; set; }

        public int SharkId { get; set; }

        public DateTime PingDateTime { get; set; }
    }
}
