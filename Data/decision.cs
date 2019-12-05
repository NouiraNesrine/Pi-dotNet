namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("decision")]
    public partial class decision
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public decision()
        {
            evaluationsheet = new HashSet<evaluationsheet>();
        }

        [Key]
        public int idDecision { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreationDec { get; set; }

        public float score { get; set; }

        public float scoreFinal { get; set; }

        [StringLength(255)]
        public string typeDec { get; set; }

        public int? decisionRef_idDecRef { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evaluationsheet> evaluationsheet { get; set; }

        public virtual decisionreference decisionreference { get; set; }
    }
}
