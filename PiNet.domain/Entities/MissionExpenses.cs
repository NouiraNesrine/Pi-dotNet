namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.missionexpenses")]
    public partial class MissionExpenses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MissionExpenses()
        {
            expensenote = new HashSet<ExpenseNote>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int refrence { get; set; }

        [Column(TypeName = "bit")]
        public bool? isApproved { get; set; }

        public double totalRecovered { get; set; }

        public int? mission_refrence { get; set; }

        public virtual Mission mission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenseNote> expensenote { get; set; }
    }
}
