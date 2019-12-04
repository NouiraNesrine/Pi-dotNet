namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.otherexpenses")]
    public partial class OtherExpenses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OtherExpenses()
        {
            expensenote = new HashSet<ExpenseNote>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string bill { get; set; }

        public double costs { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenseNote> expensenote { get; set; }
    }
}
