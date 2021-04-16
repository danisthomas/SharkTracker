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
    public class SharkTagListItem
    {
        public int SharkTagId { get; set; }

        [ForeignKey(nameof(shark))]
        public int SharkId { get; set; }
        public virtual Shark shark { get; set; }

        [Display(Name = "Shark Name")]
        public string SharkName { get; set; }
        public  Species Species { get; set; }
        public Gender Sex { get; set; }

        [Display(Name ="Length of Shark")]
        public int Length { get; set; }

        [Display(Name ="Weight of Shark")]
        public int Weight { get; set; }

        [Display(Name ="Age of Shark")]
        public Age Age { get; set; }


        [ForeignKey(nameof(tag))]
        public int TagId { get; set; }
        public virtual Tag tag { get; set; }

        [Display(Name ="Tag Serial Number")]
        public string TagSerialNumber { get; set; }


        [ForeignKey(nameof(location))]
        [Display(Name ="Location Id")]
        public int LocationId { get; set; }
        public virtual Location location { get; set; }

        [Display(Name ="Tagging Location")]
        public string TaggingLocation { get; set; }

        [Display(Name = "Date Tag was Placed")]
        public DateTimeOffset StartDate { get; set; }

        [Display(Name = "Date Tag was Removed or Lost")]
        public DateTimeOffset? EndDate { get; set; }


    }
}
