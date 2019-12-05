namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.missionexpenses")]
    public partial class missionexpens
    {
        [Key]
        public int refrence { get; set; }

        [Column(TypeName = "bit")]
        public bool? isApproved { get; set; }

        public double totalRecovered { get; set; }

        public int? mission_refrence { get; set; }
    }
}
