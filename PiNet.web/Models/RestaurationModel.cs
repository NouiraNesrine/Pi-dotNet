using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiNet.web.Models
{
    public class RestaurationModel
    {
        public int id { get; set; }

        public double costs { get; set; }

        [StringLength(255)]
        public string restaurationBill { get; set; }
    }
}