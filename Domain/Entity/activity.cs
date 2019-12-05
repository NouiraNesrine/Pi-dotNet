namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.activity")]
    public partial class activity
    {
        public int id { get; set; }

        public int NombreHeuresEstimer { get; set; }

        public int NombreHeuresTravailler { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateFin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datedebut { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string statut { get; set; }

        public int? projet_id { get; set; }

        public int? user_idUser { get; set; }
    }
}
