namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.formation")]
    public partial class formation
    {
        [Key]
        public int idFormation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDebutF { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFinF { get; set; }

        [StringLength(255)]
        public string Formateur { get; set; }

        [StringLength(255)]
        public string NomF { get; set; }

        public int? skillsF_idSkills { get; set; }
    }
}
