using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiNet.web.Models
{
   public enum AccType { Hotel, SpecialAcc, PrivateAcc }
    public class AccommodationModel
    {
        public int id { get; set; }

        [StringLength(255)]
        public string accommodationBill { get; set; }
        
        public AccType acctype { get; set; }

        public double costs { get; set; }

        public int duration { get; set; }

        public bool idFoodIncluded { get; set; }
    }
}