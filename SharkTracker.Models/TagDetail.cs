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
    public class TagDetail
    {
        
        public int TagId { get; set; }

       [Display(Name ="Tag Manufacturer")]
        public string TagManufacturer { get; set; }

      [Display(Name ="Tag Model")]
        public string TagModel { get; set; }

      [Display(Name ="Tag Serial Number")]

        public string TagSerialNumber { get; set; }
    }
}
