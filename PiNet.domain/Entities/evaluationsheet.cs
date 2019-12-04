namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.evaluationsheet")]
    public partial class evaluationsheet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public evaluationsheet()
        {
            decision = new HashSet<decision>();
        }

        [Key]
        public int evalId { get; set; }

        [Column(TypeName = "tinyblob")]
        public byte[] commentaire { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreation { get; set; }

        public float noteEmploye { get; set; }

        public float noteManager { get; set; }

        public int? objectif_idObjectif { get; set; }

        public int? user_idUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<decision> decision { get; set; }

        public virtual objectif objectif { get; set; }

        public virtual User user { get; set; }
    }
}
