namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.commentaire")]
    public partial class commentaire
    {
        [Key]
        public int idCommentaire { get; set; }

        [StringLength(255)]
        public string descriptionCom { get; set; }

        [Column(TypeName = "bit")]
        public bool? jaime { get; set; }

        public int? statous_idStatu { get; set; }

        public int? useToCom_idUser { get; set; }
    }
}
