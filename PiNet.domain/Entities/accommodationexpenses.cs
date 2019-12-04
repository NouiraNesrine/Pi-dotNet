namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.accommodationexpenses")]
    public partial class AccommodationExpenses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccommodationExpenses()
        {
            expenseNote = new HashSet<ExpenseNote>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string accommodationBill { get; set; }

        [StringLength(255)]
        public string acctype { get; set; }

        public double costs { get; set; }

        public int duration { get; set; }

        [Column(TypeName = "bit")]
        public bool? idFoodIncluded { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenseNote> expenseNote { get; set; }
    }
}
