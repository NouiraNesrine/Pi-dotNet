namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.skills")]
    public partial class skill
    {
        [Key]
        public int idSkills { get; set; }

        public int? categorie { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? niveau { get; set; }

        [StringLength(255)]
        public string nomCompetence { get; set; }

        public int? skillsRef { get; set; }
    }
}
