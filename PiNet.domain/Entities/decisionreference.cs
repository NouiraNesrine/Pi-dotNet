namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.decisionreference")]
    public partial class decisionreference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public decisionreference()
        {
            decision = new HashSet<decision>();
        }

        [Key]
        public int idDecRef { get; set; }

        public int maxAugSalaire { get; set; }

        public int maxPrime { get; set; }

        public int minAugSalaire { get; set; }

        public int minPrime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<decision> decision { get; set; }
    }
}
