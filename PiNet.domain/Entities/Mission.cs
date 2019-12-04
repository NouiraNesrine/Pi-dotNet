namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.mission")]
    public partial class Mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mission()
        {
            expensenote = new HashSet<ExpenseNote>();
            missionexpenses = new HashSet<MissionExpenses>();
            skillsRequired = new HashSet<Skills>();
            participants = new HashSet<User>();
        }

        [Key]
        public int refrence { get; set; }

        [StringLength(255)]
        public string client { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public DateTime? date_finish { get; set; }

        public DateTime? date_start { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public double estimated_budget { get; set; }

        [Column(TypeName = "bit")]
        public bool? isAnnulationRisque { get; set; }

        [Column(TypeName = "bit")]
        public bool? isPosterManager { get; set; }

        [Column(TypeName = "bit")]
        public bool? isRembursable { get; set; }

        [StringLength(255)]
        public string place_intervention { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? postedBy_idUser { get; set; }

        public int? suprvisedBy_idUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenseNote> expensenote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MissionExpenses> missionexpenses { get; set; }

        public virtual User suprvisedBy { get; set; }

        public virtual User postedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skills> skillsRequired { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> participants { get; set; }
    }
}
