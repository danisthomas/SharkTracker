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

       [Display(Name ="Ping location")]
        public string PingLocation { get; set; }

     
        [ForeignKey(nameof(sharkTag))]
        public int SharkTagId { get; set; }
        [Display(Name ="Shark Name")]
        public string SharkName { get; set; }
        public virtual SharkTag sharkTag { get; set; }
        [Display(Name ="Date of Ping")]
        public DateTime PingDate { get; set; }
    }
}
