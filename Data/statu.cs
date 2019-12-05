namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.statu")]
    public partial class statu
    {
        [Key]
        public int idStatu { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? useToSta_idUser { get; set; }
    }
}
