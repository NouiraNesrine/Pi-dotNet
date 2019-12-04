using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiNet.web.Models
{
    public class OtherModel
    {
        public int id { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string bill { get; set; }

        public double costs { get; set; }

        

        
    }
}