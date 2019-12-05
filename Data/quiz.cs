namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public enum Categorie
    {
        finance, devlopement, analyse
    }

    [Table("pidev.quiz")]
    public partial class quiz
    {
        [Key]
        public int Idq { get; set; }

        [StringLength(255)]
        public string q1 { get; set; }

        [StringLength(255)]
        public string q2 { get; set; }

        [StringLength(255)]
        public string q3 { get; set; }

        [StringLength(255)]
        public string r1j { get; set; }

        [StringLength(255)]
        public string r1f1 { get; set; }

        [StringLength(255)]
        public string r1f2 { get; set; }
        public string r2f1 { get; set; }
        public string r2f2 { get; set; }
        public string r3f1 { get; set; }

        public string r3f2 { get; set; }
        public string r2j { get; set; }
        public string r3j { get; set; }


        public Categorie categorie { get; set; }
    }
}
