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
    public class TagCreate
    {
        public int TagId { get; set; }


        [Required]
        public string TagManufacturer { get; set; }

        [Required]
        public string TagModel { get; set; }

        [Required]
        public string TagSerialNumber { get; set; }
    }
}
