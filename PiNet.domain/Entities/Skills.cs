namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.skills")]
    public partial class Skills
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skills()
        {
            formation = new HashSet<formation>();
            jobdescription = new HashSet<jobdescription>();
            mission = new HashSet<Mission>();
            user = new HashSet<User>();
        }

        [Key]
        public int idSkills { get; set; }

        [StringLength(255)]
        public string categorie { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string niveau { get; set; }

        [StringLength(255)]
        public string nomCompetence { get; set; }

        [StringLength(255)]
        public string skillsRef { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formation> formation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<jobdescription> jobdescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mission> mission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> user { get; set; }
    }
}
