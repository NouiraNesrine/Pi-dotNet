namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.timesheet")]
    public partial class timesheet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public timesheet()
        {
            activity = new HashSet<activity>();
        }

        public int id { get; set; }

        public int NombreHeureParJour { get; set; }

        public int NombreJoursTravailler { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateArrivee { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateSortie { get; set; }

        [StringLength(255)]
        public string isActive { get; set; }

        public int nombredejourscongés { get; set; }

        public int? user_idUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<activity> activity { get; set; }

        public virtual User user { get; set; }
    }
}
