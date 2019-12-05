namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.decisionreference")]
    public partial class decisionreference
    {
        [Key]
        public int idDecRef { get; set; }

        public int maxAugSalaire { get; set; }

        public int maxPrime { get; set; }

        public int minAugSalaire { get; set; }

        public int minPrime { get; set; }
    }
}
