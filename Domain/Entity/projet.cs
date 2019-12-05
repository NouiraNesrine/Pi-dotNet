namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.projet")]
    public partial class projet
    {
        public int id { get; set; }

        public int NombreHeuresEnRetard { get; set; }

        public int NombreHeuresEstimer { get; set; }

        public int NombreHeuresTravailler { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string mailClient { get; set; }

        [StringLength(255)]
     
        public string nom { get; set; }

     //   public virtual ICollection<activity> Activities { get; set; }
    }
}
