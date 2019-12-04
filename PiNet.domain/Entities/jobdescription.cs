namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.jobdescription")]
    public partial class jobdescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public jobdescription()
        {
            skills = new HashSet<Skills>();
        }

        [Key]
        public int idJob { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? niveau { get; set; }

        [StringLength(255)]
        public string nom_competence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skills> skills { get; set; }
    }
}
