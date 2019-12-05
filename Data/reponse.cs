namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.reponse")]
    public partial class reponse
    {
        [Key]
        public int Idr { get; set; }

        [StringLength(255)]
        public string r1 { get; set; }

        [StringLength(255)]
        public string r2 { get; set; }

        [StringLength(255)]
        public string r3 { get; set; }

        public int? userq_idUser { get; set; }
    }
}
