using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Models
{
    public class LocationCreate
    {
       [Required]
        [Display(Name = "Tagging Location")]
        public string TaggingLocation { get; set; }
    }
}
