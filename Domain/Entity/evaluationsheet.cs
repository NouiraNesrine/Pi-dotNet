namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.evaluationsheet")]
    public partial class evaluationsheet
    {
        [Key]
        public int evalId { get; set; }

       // [Column(TypeName = "tinyblob")]
        public byte[] commentaire { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreation { get; set; }

        public float noteEmploye { get; set; }

        public float noteManager { get; set; }

        public int? objectif_idObjectif { get; set; }

        public int? user_idUser { get; set; }
    }
}
