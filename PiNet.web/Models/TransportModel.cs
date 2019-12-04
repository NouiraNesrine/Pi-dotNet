using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiNet.web.Models
{
    public class TransportModel
    {
        public int id { get; set; }

        [StringLength(255)]
        public string boardingTicket { get; set; }

        public double costs { get; set; }

        public double kms { get; set; }

        [StringLength(255)]
        public string trspType { get; set; }

        public double visa { get; set; }
    }
}