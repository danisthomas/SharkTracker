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
    public class SharkTagDetail

      
    {
        public int SharkTagId { get; set; }

        [ForeignKey(nameof(shark))]
        public int SharkId { get; set; }
        public virtual Shark shark { get; set; }

        [Display(Name ="Shark Name")]
        public string SharkName { get; set; }

        [ForeignKey(nameof(tag))]
        public int TagId { get; set; }
        public virtual Tag tag { get; set; }

        [Display(Name ="Tag Serial Number")]
        public string TagSerialNumber { get; set; }

        [ForeignKey(nameof(location))]
        public int LocationId { get; set; }
        public virtual Location location { get; set; }

        [Display(Name ="Location Tagged")]
        public string TaggingLocation { get; set; }
        
        [Display(Name ="Tagging Date")]
        public DateTimeOffset  StartDate { get; set; }

        [Display(Name ="Tag Removal Date")]
        public DateTimeOffset? EndDate { get; set; }



    }

}
