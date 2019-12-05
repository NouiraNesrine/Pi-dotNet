namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.expensenote")]
    public partial class expensenote
    {
        [Key]
        public int refrence { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [Column(TypeName = "bit")]
        public bool? isApproved { get; set; }

        public double totalCost { get; set; }

        public double totalRecovered { get; set; }

        public int? employee_idUser { get; set; }

        public int? mission_refrence { get; set; }

        public int? officer_idUser { get; set; }
    }
}
