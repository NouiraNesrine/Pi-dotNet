namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.jobdescription")]
    public partial class jobdescription
    {
        [Key]
        public int idJob { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? niveau { get; set; }

        [StringLength(255)]
        public string nom_competence { get; set; }
    }
}
