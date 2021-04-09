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
       [Key,Required]
        public int SharkId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        
        public enum Species { GreatWhite=1,Tiger=2,Mako=3 }

        [Required] 
        public int Length { get; set; }

       
        public enum Sex { Female=1,Male=2 }

        [Required]
        public int Weight { get; set; }

        [Required]
        public string SharkName { get; set; }

        public enum Age { YoungOfTheYear=1, Juvenile=2,SubAdult=3,Adult=4 }

        public virtual Tag Tag { get; set; }

    }
}
