namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rate")]
    public partial class rate
    {
        [Key]
    
        public int idRate { get; set; }

        public int score { get; set; }

       
        public int? user_idUser { get; set; }

       [ForeignKey("user_idUser")]
        public virtual user user { get; set; }
    }
}
