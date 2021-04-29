using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkTracker.Models
{
    public class PingSearchView
    {
        [DisplayName("Search Query *")]
        [Required]
        public string Query { get; set; }
    }
}
