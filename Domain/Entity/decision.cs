namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.decision")]
    public partial class decision
    {
        [Key]
        public int idDecision { get; set; }

        [StringLength(255)]
        public string typeDec { get; set; }

        public int? decisionRef_idDecRef { get; set; }

        public int? evaluation_evalId { get; set; }
    }
}
