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

       
        public string TagManufacturer { get; set; }

      
        public string TagModel { get; set; }

      
        public string TagSerialNumber { get; set; }
    }
}
