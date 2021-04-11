using SharkTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Models
{
    public class SharkListItem
    {
        public int SharkId { get; set; }
        public enum Species {GreatWhite=1, Tiger=2, Mako=3}
        public int Length { get; set; }
        public enum Sex { Female=1, Male=2 }
        public int Weight { get; set; }
        public string SharkName { get; set; }
        public enum Age { YoungOfTheYear=1, Junvenile=2, SubAdult=3, Adult=4 }
        public virtual Tag Tag { get; set; }
    }
}
