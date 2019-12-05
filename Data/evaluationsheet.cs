namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("evaluationsheet")]
    public partial class evaluationsheet
    {
        [Key]
        public int evalId { get; set; }

 
        public byte[] commentaire { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreation { get; set; }

        public float noteEmploye { get; set; }

        public float noteManager { get; set; }

        public int? decision_idDecision { get; set; }

        public float rate { get; set; }

        public int? user_idUser { get; set; }

        public virtual decision decision { get; set; }

        public virtual user user { get; set; }
    }
}
