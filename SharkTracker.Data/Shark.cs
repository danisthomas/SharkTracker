﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Data
{
    public enum Species {GreatWhite, Tiger, Mako }
    public enum Gender {Male, Female }

    public enum Age { YoungOfTheYear, Juvenile, SubAdult, Adult }
    public class Shark
    {
       [Key,Required]
        public int SharkId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        
        public Species Species { get; set; }

        [Required] 
        public int Length { get; set; }

       
        public Gender  Sex { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public string SharkName { get; set; }

        public Age Age { get; set; }

        public virtual Tag Tag { get; set; }

    }
}
