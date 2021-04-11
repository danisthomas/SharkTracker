using SharkTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Models
{
   public class SharkCreate
    {
     

        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 Characters.")]
        [MaxLength(100, ErrorMessage ="There are too many characters in this field.")]
        public string SharkName { get; set; }

        [Required]
        public Species Species { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        public Gender Sex { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public Age Age { get; set; }
        
        public virtual Tag Tag { get; set; }

    }
}
