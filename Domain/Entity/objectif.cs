namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.objectif")]
    public partial class objectif
    {
        [Key]
        public int idObjectif { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
