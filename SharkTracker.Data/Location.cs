using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Data
{

   
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public string TaggingLocation { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

    }
}
