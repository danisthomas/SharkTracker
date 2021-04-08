using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Data
{
    public class Shark
    {
       [Required]
        public int SharkId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Enum Species { get; set; }

        [Required] 
        public int Length { get; set; }

        [Required]
        public Enum Sex { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public string SharkName { get; set; }

        [Required]
        public Enum Age { get; set; }

    }
}
