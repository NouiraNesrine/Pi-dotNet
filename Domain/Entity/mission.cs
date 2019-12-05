namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.mission")]
    public partial class mission
    {
        [Key]
        public int refrence { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Column(TypeName = "bit")]
        public bool? isProvidedAccd { get; set; }

        [Column(TypeName = "bit")]
        public bool? isProvidedTrsp { get; set; }

        public int participantsNumber { get; set; }

        [StringLength(255)]
        public string skillsRequired { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string subject { get; set; }

        public int? postedBy_idUser { get; set; }
    }
}
