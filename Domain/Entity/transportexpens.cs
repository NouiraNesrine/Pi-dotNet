namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.transportexpenses")]
    public partial class transportexpens
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
