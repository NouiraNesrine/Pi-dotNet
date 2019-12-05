namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.accommodationexpenses")]
    public partial class accommodationexpens
    {
        public int id { get; set; }

        [StringLength(255)]
        public string accommodationBill { get; set; }

        [StringLength(255)]
        public string acctype { get; set; }

        public double costs { get; set; }

        public int duration { get; set; }
    }
}
