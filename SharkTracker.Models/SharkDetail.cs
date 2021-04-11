using SharkTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Models
{
    public class SharkDetail
    {
        public int SharkId { get; set; }

        public string SharkName { get; set; }
        public Species Species { get; set; }
        [Display(Name = "Length in Feet")]
        public int Length { get; set; }
        public Gender Sex { get; set; }

        [Display(Name = "Weight in Lbs")]
        public int Weight { get; set; }

        public Age Age { get; set; }
       

    }
}
