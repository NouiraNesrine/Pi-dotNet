namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.expensenote")]
    public partial class ExpenseNote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpenseNote()
        {
            accommodationexpenses = new HashSet<AccommodationExpenses>();
            otherexpenses = new HashSet<OtherExpenses>();
            restaurationexpenses = new HashSet<RestaurationExpenses>();
            transportexpenses = new HashSet<TransportExpenses>();
            missionexpenses = new HashSet<MissionExpenses>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int refrence { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [Column(TypeName = "bit")]
        public bool? isApproved { get; set; }

        public double totalCost { get; set; }

        public double totalRecovered { get; set; }

        public int? employee_idUser { get; set; }

        public int? mission_refrence { get; set; }

        public int? officer_idUser { get; set; }

        public virtual Mission mission { get; set; }

        public virtual User employee { get; set; }

        public virtual User officer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccommodationExpenses> accommodationexpenses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherExpenses> otherexpenses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurationExpenses> restaurationexpenses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportExpenses> transportexpenses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MissionExpenses> missionexpenses { get; set; }
    }
}
